using System.Collections.Generic;

namespace YukimaruGames.Editor.CodeGenerator.Domain
{
    internal interface IReplacementRuleRepository
    {
        IReadOnlyList<IReplacementRule> Rules { get; }

        void Add(IReplacementRule rule);
        void Remove(IReplacementRule rule);
    }
}
