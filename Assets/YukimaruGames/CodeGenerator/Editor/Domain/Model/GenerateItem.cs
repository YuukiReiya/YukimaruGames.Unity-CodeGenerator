using System;
using UnityEngine;
using YukimaruGames.CodeGenerator.Domain;
using YukimaruGames.CodeGenerator.Infrastructure;

namespace YukimaruGames.Editor.CodeGenerator.Domain
{
    internal sealed record GenerateItem
    {
        [field:SerializeField]
        internal string TemplateFile { get; private set; }
        [field:SerializeField]
        internal string GenerateFile { get; private set; }

        internal GenerateItem(IConfig config)
        {
            TemplateFile = config.TemplateFilePath;
            GenerateFile = config.GenerateFilePath;
        }
    }
}
