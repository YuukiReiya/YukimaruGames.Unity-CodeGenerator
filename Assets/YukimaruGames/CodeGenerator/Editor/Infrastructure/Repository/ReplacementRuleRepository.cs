using System.Collections.Generic;
using YukimaruGames.Editor.CodeGenerator.Domain;

namespace YukimaruGames.Editor.CodeGenerator.Infrastructure
{
    internal sealed class ReplacementRuleRepository : IReplacementRuleRepository
    {
        private readonly List<IReplacementRule> _rules = new();
        public IReadOnlyList<IReplacementRule> Rules => _rules;
        public void Add(IReplacementRule rule)
        {
            _rules.Add(rule);
        }

        public void Remove(IReplacementRule rule)
        {
            _rules.Remove(rule);
        }

        internal void RemoveAt(int index)
        {
            _rules.RemoveAt(index);
        }

        internal void RemoveAll(string key)
        {
            _rules.RemoveAll(x => x.Key == key);
        }
    }
}
