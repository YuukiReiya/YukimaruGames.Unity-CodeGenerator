namespace YukimaruGames.Editor.CodeGenerator.Domain
{
    /// <summary>
    /// 文字列置換のインターフェイス
    /// </summary>
    public interface IReplacementRule
    {
        /// <summary>
        /// 置換文字列
        /// </summary>
        string Key { get; }
        
        /// <summary>
        /// 置換先文字列
        /// </summary>
        string Value { get; }
    }
}
