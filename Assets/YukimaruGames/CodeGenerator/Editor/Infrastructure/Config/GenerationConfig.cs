using System.Collections.Generic;
using UnityEngine;
using YukimaruGames.Editor.CodeGenerator.Domain;

namespace YukimaruGames.Editor.CodeGenerator.Infrastructure
{
    /// <summary>
    /// コード生成設定.
    /// </summary>
    public class GenerationConfig : ScriptableObject, IConfig
    {
        private readonly Dictionary<string, string> _rules = new();
        
        /// <inheritdoc/> 
        public string TemplateFilePath { get; set; }

        /// <inheritdoc/>
        public string GenerateFilePath { get; set; }

        /// <inheritdoc/>
        //public IReadOnlyCollection<IReplacementRule> Rules => _rules.Values;
        public IReadOnlyDictionary<string, string> Rules => _rules;
        public bool Add(IReplacementRule rule)
        {
            return _rules.TryAdd(rule.Key, rule.Value);
        }

        public bool Remove(string key)
        {
            return _rules.Remove(key);
        }
    }
}
