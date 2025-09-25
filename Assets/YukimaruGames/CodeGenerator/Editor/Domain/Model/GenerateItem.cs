using UnityEngine;

namespace YukimaruGames.Editor.CodeGenerator.Domain
{
    internal sealed record GenerateItem
    {
        [field:SerializeField]
        internal string TemplateFile { get; set; }
        [field:SerializeField]
        internal string GenerateFile { get; set; }

        internal GenerateItem(IConfig config)
        {
            TemplateFile = config.TemplateFilePath;
            GenerateFile = config.GenerateFilePath;
        }
    }
}
