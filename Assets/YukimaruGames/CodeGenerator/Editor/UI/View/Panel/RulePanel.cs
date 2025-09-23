using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using YukimaruGames.CodeGenerator.Domain;

namespace YukimaruGames.Editor.CodeGenerator.View
{
    internal sealed class RulePanel : IDisposable
    {
        private readonly IIconRepository _iconRepository;
        private readonly IReadOnlyCollection<IReplacementRule> _rules;
        private readonly Lazy<GUIContent> _keyContentLazy;
        private readonly Lazy<GUIContent> _valueContentLazy;
        private readonly Lazy<GUIContent> _deleteButtonContentLazy;

        private Vector2 _scrollPosition;
        
        internal RulePanel(IIconRepository iconRepository, IReadOnlyCollection<IReplacementRule> rules)
        {
            _iconRepository = iconRepository;
            _rules = rules;

            //_keyContentLazy = new Lazy<GUIContent>(EditorStyles.fie)
        }

        ~RulePanel()
        {
            IDisposable self = this;
            self.Dispose();
        }

        void IDisposable.Dispose()
        {
            // TODO マネージリソースをここで解放します
        }
        
        internal void Show()
        {
            using var scope = new EditorGUILayout.ScrollViewScope(_scrollPosition, EditorStyles.helpBox);
            _scrollPosition = scope.scrollPosition;
            DrawRules();
        }

        private void DrawRules()
        {
            using var scope = new EditorGUILayout.VerticalScope();
            foreach (var rule in _rules)
            {
                DrawRule(rule);
            }
        }

        private void DrawRule(IReplacementRule rule)
        {
            
        }
    }
}
