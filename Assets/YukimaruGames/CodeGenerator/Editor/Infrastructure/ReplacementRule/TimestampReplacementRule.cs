using System;
using YukimaruGames.Editor.CodeGenerator.Domain;

namespace YukimaruGames.Editor.CodeGenerator.Infrastructure
{
    /// <summary>
    /// 文字列のタイムスタンプ置換
    /// </summary>
    public sealed class TimestampReplacementRule : IReplacementRule
    {
        /// <inheritdoc/>
        public string Key => "%TIMESTAMP%";
        /// <inheritdoc/>
        public string Value => DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
    }
}
