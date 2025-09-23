using System;

namespace YukimaruGames.Editor.CodeGenerator.View
{
    public interface IGenerateFilePanel
    {
        event Action<string> OnEditTemplateFile;
        event Action<string> OnEditGenerateFile;
        event Action OnRemove;
    }
}
