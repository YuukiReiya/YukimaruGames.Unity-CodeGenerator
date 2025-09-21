using UnityEngine;
using YukimaruGames.CodeGenerator.Domain;

namespace YukimaruGames.CodeGenerator.Infrastructure
{
    /// <summary>
    /// <p>カスタム文字列置換.</p>
    /// <p>任意の文字列を指定文字列に置換するルール</p>
    /// </summary>
    public sealed class CustomReplacementRule : ScriptableObject, IReplacementRule
    {
        /// <inheritdoc/> 
        public string Key { get; set; }

        /// <inheritdoc/>
        public string Value { get; set; }
    }
}
