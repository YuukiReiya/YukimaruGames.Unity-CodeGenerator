using System;
using YukimaruGames.CodeGenerator.Domain;

namespace YukimaruGames.CodeGenerator.Infrastructure
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
