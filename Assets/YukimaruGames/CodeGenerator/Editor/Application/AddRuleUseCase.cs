using YukimaruGames.Editor.CodeGenerator.Domain;
using YukimaruGames.Editor.CodeGenerator.Infrastructure;

namespace YukimaruGames.Editor.CodeGenerator.Application
{
    internal sealed class AddRuleUseCase
    {
        private readonly IReplacementRuleRepository _repository;
        internal AddRuleUseCase(IReplacementRuleRepository repository)
        {
            _repository = repository;
        }

        internal void Add(IReplacementRule rule)
        {
            _repository.Add(rule);
        }

        internal void Add(string replacementTarget, string replacementText)
        {
            _repository.Add(new CustomReplacementRule
            {
                Key = replacementTarget,
                Value = replacementText
            });
        }

        internal void Add() => Add(string.Empty, string.Empty);
    }
}
