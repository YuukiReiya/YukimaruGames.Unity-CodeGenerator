using System.Collections.Generic;
using UnityEngine;
using YukimaruGames.CodeGenerator.Domain;

namespace YukimaruGames.CodeGenerator.Infrastructure
{
    /// <summary>
    /// コード生成設定.
    /// </summary>
    public class GenerationConfig : ScriptableObject, IConfig
    {
        /// <inheritdoc/> 
        public string TemplateFilePath { get; set; }

        /// <inheritdoc/>
        public string GenerateFilePath { get; set; }

        /// <inheritdoc/>
        public IReadOnlyList<IReplacementRule> Rules { get; set; }
    }
}
