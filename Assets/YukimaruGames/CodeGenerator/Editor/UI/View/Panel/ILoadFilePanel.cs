 using System;

namespace YukimaruGames.Editor.CodeGenerator.View
{
    internal interface ILoadFilePanel
    {
        event Action<string> OnExecuteLoad;
    }
}
