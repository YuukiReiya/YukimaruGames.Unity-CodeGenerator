using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using YukimaruGames.Editor.CodeGenerator.Domain;
using YukimaruGames.Editor.CodeGenerator.Infrastructure;

namespace YukimaruGames.Editor.CodeGenerator.View
{
    internal sealed class GenerateFilePanel : IGenerateFilePanel
    {
        private readonly IGenerateItemRepository _itemRepository;
        private readonly IIconRepository _iconRepository;
        private readonly Lazy<GUIStyle> _headerStyleLazy;
        private readonly Lazy<GUIContent> _deleteButtonContentLazy;
        private readonly ReorderableList _reorderableList;
        private readonly Queue<int> _deleteQueue = new();

        private Vector2 _scrollPosition;


        private const string Template = "Template";
        private const string Generate = "Generate";
        private const string Delete = "Delete";
        
        public event Action<string> OnEditTemplateFile;
        public event Action<string> OnEditGenerateFile;
        public event Action OnRemove;

        internal GenerateFilePanel(IGenerateItemRepository itemRepository,IIconRepository iconRepository)
        {
            _itemRepository = itemRepository;
            _iconRepository = iconRepository;
            _reorderableList = new ReorderableList(_itemRepository.Items, typeof(GenerateItem), true, true, true, true)
            {
                drawHeaderCallback = DrawHeader,
                drawElementCallback = DrawItem,
                onAddCallback = OnAddItem,
                elementHeight = 20,
            };
            _headerStyleLazy = new Lazy<GUIStyle>(() =>
            {
                var style = new GUIStyle(GUI.skin.label)
                {
                    alignment = TextAnchor.MiddleCenter,
                    fontStyle = FontStyle.Bold,
                };
                return style;
            });
            _deleteButtonContentLazy = new Lazy<GUIContent>(() => new GUIContent(string.Empty, iconRepository.GetIcon("d_TreeEditor.Trash")));
        }

        internal void Show()
        {
            DrawScrollList();
            DeleteIfNeeded();
        }

        private void DrawItem(Rect rect, int index, bool isActive, bool isFocused)
        {
            var item = _itemRepository.Items[index] as GenerateItem;

            var deleteButtonRect = MakePaddingRect(rect);
            MaterializeDeleteButtonRect(ref deleteButtonRect);
            
            var templateRect = MakePaddingRect(rect);
            MaterializeTemplateRect(ref templateRect);

            var generateRect = MakePaddingRect(rect);
            MaterializeGenerateRect(ref generateRect, templateRect);

            // 削除
            if (GUI.Button(deleteButtonRect, _deleteButtonContentLazy.Value))
            {
                _deleteQueue.Enqueue(index);
            }
            
            // テンプレート
            var newTemplateFilePath = EditorGUI.TextField(templateRect, item!.TemplateFile);
            if (item.TemplateFile != newTemplateFilePath)
            {
                item.TemplateFile = newTemplateFilePath;
            }
            
            // 書き出しファイル
            var newGenerateFile = EditorGUI.TextField(generateRect, item.GenerateFile);
            if (item.GenerateFile != newGenerateFile)
            {
                item.GenerateFile = newGenerateFile;
            }
        }

        private void DrawHeader(Rect rect)
        {
            var templateRect = MakePaddingRect(rect);
            MaterializeTemplateRect(ref templateRect);

            var generateRect = MakePaddingRect(rect);
            MaterializeGenerateRect(ref generateRect, templateRect);

            var deleteButtonRect = MakePaddingRect(rect);
            MaterializeDeleteButtonRect(ref deleteButtonRect);

            EditorGUI.LabelField(templateRect, Template, _headerStyleLazy.Value);
            EditorGUI.LabelField(generateRect, Generate, _headerStyleLazy.Value);
            EditorGUI.LabelField(deleteButtonRect, Delete, _headerStyleLazy.Value);
        }

        private void DrawScrollList()
        {
            using var scope = new EditorGUILayout.ScrollViewScope(_scrollPosition);
            _scrollPosition = scope.scrollPosition;
            _reorderableList.DoLayoutList();
        }

        private void DeleteIfNeeded()
        {
            while (0 < _deleteQueue.Count)
            {
                var index = _deleteQueue.Dequeue();
                _itemRepository.Items.RemoveAt(index);
            }
        }

        private Rect MakePaddingRect(in Rect rect)
        {
            const int padding = 2;
            return new Rect(
                rect.x + padding,
                rect.y + padding,
                rect.width - padding * 2,
                rect.height - padding * 2
            );
        }
        
        private void MaterializeTemplateRect(ref Rect paddingRect)
        {
            paddingRect.width *= 0.45f;
        }

        private void MaterializeGenerateRect(ref Rect paddingRect,in Rect templateRect)
        {
            const int space = 4;
            paddingRect.x = templateRect.x + templateRect.width + space;
            paddingRect.width = templateRect.width;
        }
        
        private void MaterializeDeleteButtonRect(ref Rect paddingRect)
        {
            const float width = 50;
            paddingRect.x += paddingRect.width - width;
            paddingRect.width = width;
        }
        
        private void OnAddItem(ReorderableList _)
        {
            _itemRepository.AddItem(new GenerationConfig());
        }
    }
}
