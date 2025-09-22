using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using YukimaruGames.Editor;

namespace YukimaruGames.CodeGenerator
{
    public sealed class CodeGenWindow : EditorWindow
    {
        private IIconRepository _iconRepository;
        private Vector2 _scrollPosition;
        
        private const string kToolName = "CodeGen";

        [MenuItem("YukimaruGames/" + kToolName)]
        public static void ShowWindow()
        {
            GetWindow<CodeGenWindow>(kToolName);
        }

        private void OnGUI()
        {
            using var scope = new GUILayout.ScrollViewScope(_scrollPosition);
            _scrollPosition = scope.scrollPosition;
            
            DrawPanel();
        }

        private void OnEnable() => SetUp();

        private void OnDisable() => TearDown();

        private void SetUp()
        {
            _iconRepository = new BuiltinEditorIconRepository();
        }

        private void TearDown()
        {
            var disposables = new object[]
            {
                _iconRepository,

            }.OfType<IDisposable>();

            foreach (var disposer in disposables)
            {
                disposer.Dispose();
            }

            _iconRepository = null;
        }

        private void DrawPanel()
        {
            
        }
    }
}
