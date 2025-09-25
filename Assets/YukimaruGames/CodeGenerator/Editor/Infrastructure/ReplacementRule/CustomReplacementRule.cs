using YukimaruGames.Editor.CodeGenerator.Domain;

namespace YukimaruGames.Editor.CodeGenerator.Infrastructure
{
    /// <summary>
    /// <p>カスタム文字列置換.</p>
    /// <p>任意の文字列を指定文字列に置換するルール</p>
    /// </summary>
    public sealed class CustomReplacementRule : IReplacementRule
    {
        /// <inheritdoc/> 
        public string Key { get; set; }

        /// <inheritdoc/>
        public string Value { get; set; }
    }
}
