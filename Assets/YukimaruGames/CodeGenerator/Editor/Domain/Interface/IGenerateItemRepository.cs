using System.Collections;

namespace YukimaruGames.Editor.CodeGenerator.Domain
{
    internal interface IGenerateItemRepository
    {
        IList Items { get; }

        void AddItem(IConfig config);
        void RemoveItem(IConfig config);
    }
}
