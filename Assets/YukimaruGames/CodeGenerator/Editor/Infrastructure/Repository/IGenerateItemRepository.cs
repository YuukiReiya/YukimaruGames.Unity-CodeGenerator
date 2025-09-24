using System.Collections;
using YukimaruGames.CodeGenerator.Domain;

namespace YukimaruGames.CodeGenerator.Infrastructure
{
    internal interface IGenerateItemRepository
    {
        IList Items { get; }

        void AddItem(IConfig config);
        void RemoveItem(IConfig config);
    }
}
