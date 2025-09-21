using UnityEngine;

namespace YukimaruGames.Editor
{
    /// <summary>
    /// アイコンのリポジトリインターフェイス 
    /// </summary>
    internal interface IIconRepository
    {
        /// <summary>
        /// アイコンのテクスチャ取得
        /// </summary>
        Texture GetIcon(string iconName);
    }
}
