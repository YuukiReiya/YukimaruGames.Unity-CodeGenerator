using System;
using UnityEditor;
using UnityEngine;

namespace YukimaruGames.Editor.CodeGenerator.View
{
    internal sealed class LoadFilePanel : ILoadFilePanel, IDisposable
    {
        private readonly IIconRepository _iconRepository;

        private readonly Lazy<GUIContent> _headerContentLazy;
        private readonly Lazy<GUIContent> _inputFieldContentLazy;
        private readonly Lazy<GUIContent> _browseButtonContentLazy;
        private readonly Lazy<GUIContent> _loadButtonContentLazy;

        private string _filePath;
        
        private const float kBrowseButtonWidth = 74;
        private const string kBrowseOpenFileTitle = "Select File";
        private const string kFileExtensions = "cs,template";
        public event Action<string> OnExecuteLoad;
        internal LoadFilePanel(IIconRepository iconRepository)
        {
            _iconRepository = iconRepository;
            _headerContentLazy = new Lazy<GUIContent>(
                () => new GUIContent(
                    "Select File:",
                    _iconRepository.GetIcon("d_Profiler.FileAccess")));
            _inputFieldContentLazy = new Lazy<GUIContent>(new GUIContent("File Path"));
            _browseButtonContentLazy = new Lazy<GUIContent>(
                () => new GUIContent(
                    "Browse",
                    iconRepository.GetIcon("Folder")));
            _loadButtonContentLazy = new Lazy<GUIContent>(
                () => new GUIContent(
                    "Load File",
                    iconRepository.GetIcon("Download-Available")));
        }

        ~LoadFilePanel()
        {
            IDisposable self = this;
            self.Dispose();
        }
        
        void IDisposable.Dispose()
        {
            _filePath = null;
            OnExecuteLoad = null;
        }

        internal void Show()
        {
            using var scope = new EditorGUILayout.VerticalScope(EditorStyles.helpBox);
            DrawHeader();
            using (new EditorGUILayout.HorizontalScope())
            {
                DrawInputField();
                DrawBrowseButton();
            }

            DrawLoadButton();
        }

        private void DrawHeader()
        {
            EditorGUILayout.LabelField(_headerContentLazy.Value, EditorStyles.boldLabel);
        }

        private void DrawInputField()
        {
            _filePath = EditorGUILayout.TextField(_inputFieldContentLazy.Value, _filePath);
        }

        private void DrawBrowseButton()
        {
            if (!GUILayout.Button(_browseButtonContentLazy.Value, GUILayout.Width(kBrowseButtonWidth)))
            {
                return;
            }

            var path = EditorUtility.OpenFilePanel(kBrowseOpenFileTitle, string.Empty, kFileExtensions);
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            _filePath = path;
        }

        private void DrawLoadButton()
        {
            var clicked = GUILayout.Button(_loadButtonContentLazy.Value);
            if (clicked)
            {
                OnExecuteLoad?.Invoke(_filePath);
            }
        } 
    }
}
