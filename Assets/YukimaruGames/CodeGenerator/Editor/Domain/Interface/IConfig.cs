using System.Collections.Generic;

namespace YukimaruGames.CodeGenerator.Domain
{
    /// <summary>
    /// 基本設定インターフェイス
    /// </summary>
    public interface IConfig
    {
        /// <summary>
        /// テンプレートとして読み込むファイルのパス
        /// </summary>
        string TemplateFilePath { get; }
        
        /// <summary>
        /// 生成先のファイルパス
        /// </summary>
        string GenerateFilePath { get; }
        
        /// <summary>
        /// 文字列の置換ルール
        /// </summary>
        IReadOnlyList<IReplacementRule> Rules { get; }
    }
}
