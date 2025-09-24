using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using YukimaruGames.CodeGenerator.Infrastructure;
using YukimaruGames.Editor;
using YukimaruGames.Editor.CodeGenerator;
using YukimaruGames.Editor.CodeGenerator.Infrastructure;
using YukimaruGames.Editor.CodeGenerator.View;

namespace YukimaruGames.CodeGenerator
{
    public sealed class CodeGenWindow : EditorWindow, IRectProvider
    {
        private GenerateItemRepository _itemRepository;
        private IIconRepository _iconRepository;

        private LoadFilePanel _loadFilePanel;

        //private RulePanel _rulePanel;
        private GenerateFilePanel _generateFilePanel;
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
            //_itemRepository = new 
            _iconRepository = new BuiltinEditorIconRepository();
            _loadFilePanel = new LoadFilePanel(_iconRepository);
            _itemRepository = new GenerateItemRepository();
            
            var config = new GenerationConfig();
            config.Add(new TimestampReplacementRule());
            _itemRepository.AddItem(config);

            _generateFilePanel = new GenerateFilePanel(_itemRepository, _iconRepository, this);
            //_rulePanel = new RulePanel(_iconRepository,);
        }

        private void TearDown()
        {
            var disposables = new object[]
            {
                _iconRepository,
                _loadFilePanel,
                _generateFilePanel,
            }.OfType<IDisposable>();

            foreach (var disposer in disposables)
            {
                disposer.Dispose();
            }

            _iconRepository = null;
            _loadFilePanel = null;
            _generateFilePanel = null;
        }

        private void DrawPanel()
        {
            _loadFilePanel.Show();
            _generateFilePanel.Show();
        }

        Rect IRectProvider.GetRect() => position;
    }
}
