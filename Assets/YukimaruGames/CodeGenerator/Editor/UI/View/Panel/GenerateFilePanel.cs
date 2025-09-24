using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using YukimaruGames.CodeGenerator.Domain;
using YukimaruGames.CodeGenerator.Infrastructure;
using YukimaruGames.Editor.CodeGenerator.Domain;

namespace YukimaruGames.Editor.CodeGenerator.View
{
    internal sealed class GenerateFilePanel : IGenerateFilePanel
    {
        private readonly IGenerateItemRepository _itemRepository;
        private readonly IIconRepository _iconRepository;
        private readonly IRectProvider _windowRectProvider;
        private readonly Lazy<GUIStyle> _inputFieldStyleLazy;
        private readonly Lazy<GUIContent> _deleteButtonContentLazy;
        private readonly ReorderableList _reorderableList;
        
        
        private Rect _cachedRect;
        private bool _shouldRecalculation = true;

        private const float InputFieldWidth = 200f;
        private const float _buttonWidth = 50f;
        
        public event Action<string> OnEditTemplateFile;
        public event Action<string> OnEditGenerateFile;
        public event Action OnRemove;

        internal GenerateFilePanel(IGenerateItemRepository itemRepository,IIconRepository iconRepository, IRectProvider windowRectProvider)
        {
            _itemRepository = itemRepository;
            _iconRepository = iconRepository;
            _reorderableList = new ReorderableList(_itemRepository.Items, typeof(GenerateItem), true, true, true, true)
            {
                drawElementCallback = null,
                elementHeight = 20,
            };
            _windowRectProvider = windowRectProvider;
            _inputFieldStyleLazy = new Lazy<GUIStyle>(() =>
            {
                return new GUIStyle(GUI.skin.textField);
            });
            _deleteButtonContentLazy = new Lazy<GUIContent>(() => new GUIContent(string.Empty, iconRepository.GetIcon("d_TreeEditor.Trash")));
            _cachedRect = _windowRectProvider.GetRect();
        }

        internal void Show()
        {
            DrawHeader();
            DrawConfig();
        }

        private void DrawHeader()
        {
            using var scope = new EditorGUILayout.HorizontalScope();
            var content = new GUIStyle(EditorStyles.boldLabel);
            content.alignment = TextAnchor.MiddleCenter;
            content.fixedWidth = InputFieldWidth;
            EditorGUILayout.LabelField("Template", content, GUILayout.Width(InputFieldWidth));
            EditorGUILayout.LabelField("Generate", content, GUILayout.Width(InputFieldWidth));
            EditorGUILayout.LabelField("Delete", content, GUILayout.Width(InputFieldWidth));
        }

        private void DrawItem(Rect rect, int index, bool isActive, bool isFocused)
        {
            var item = _itemRepository.Items[index];
            
            // 削除ボタン.
        }
        
        private void DrawConfig()
        {
            // using var scope = new EditorGUILayout.HorizontalScope();
            // var newText = EditorGUILayout.TextField(_config.TemplateFilePath, GUILayout.Width(InputFieldWidth));
            // if (_config.TemplateFilePath != newText)
            // {
            //     OnEditTemplateFile?.Invoke(newText);
            // }
            //
            // newText =  EditorGUILayout.TextField(_config.GenerateFilePath, GUILayout.Width(InputFieldWidth));
            // if (_config.GenerateFilePath != newText)
            // {
            //     OnEditGenerateFile?.Invoke(newText);
            // }
            //
            // if (GUILayout.Button("X", GUILayout.Width(InputFieldWidth)))
            // {
            //     OnRemove?.Invoke();
            // }
        }
        
        // private void Recalculate()
        // {
        //     _openButtonTextSize = CalcCompactButtonTextSize();
        //     _closeButtonTextSize = CalcFullButtonTextSize();
        //     _shouldRecalculation = false;
        // }
    }
}
