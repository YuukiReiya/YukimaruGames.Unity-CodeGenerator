using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using YukimaruGames.CodeGenerator.Domain;

namespace YukimaruGames.Editor.CodeGenerator.View
{
    internal sealed class GenerateFilePanel : IGenerateFilePanel
    {
        private readonly IIconRepository _iconRepository;
        private readonly IConfig _config;
        private readonly IRectProvider _windowRectProvider;
        private readonly Lazy<GUIStyle> _inputFieldStyleLazy;
        
        private Rect _cachedRect;
        private bool _shouldRecalculation = true;

        private const float InputFieldWidth = 200f;
        private const float _buttonWidth = 50f;
        
        public event Action<string> OnEditTemplateFile;
        public event Action<string> OnEditGenerateFile;
        public event Action OnRemove;

        internal GenerateFilePanel(IIconRepository iconRepository, IConfig config, IRectProvider windowRectProvider)
        {
            _iconRepository = iconRepository;
            _config = config;
            _windowRectProvider = windowRectProvider;
            _inputFieldStyleLazy = new Lazy<GUIStyle>(() =>
            {
                return new GUIStyle(GUI.skin.textField);
            });
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
        
        private void DrawConfig()
        {
            using var scope = new EditorGUILayout.HorizontalScope();
            var newText = EditorGUILayout.TextField(_config.TemplateFilePath, GUILayout.Width(InputFieldWidth));
            if (_config.TemplateFilePath != newText)
            {
                OnEditTemplateFile?.Invoke(newText);
            }
            
            newText =  EditorGUILayout.TextField(_config.GenerateFilePath, GUILayout.Width(InputFieldWidth));
            if (_config.GenerateFilePath != newText)
            {
                OnEditGenerateFile?.Invoke(newText);
            }

            if (GUILayout.Button("X", GUILayout.Width(InputFieldWidth)))
            {
                OnRemove?.Invoke();
            }
        }
        
        // private void Recalculate()
        // {
        //     _openButtonTextSize = CalcCompactButtonTextSize();
        //     _closeButtonTextSize = CalcFullButtonTextSize();
        //     _shouldRecalculation = false;
        // }
    }
}
