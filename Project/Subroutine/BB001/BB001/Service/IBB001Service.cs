using System.Collections.Generic;

namespace BB001
{
    /// <summary>
    /// B001 interface
    /// </summary>
    public interface IBB001Service
    {
        /// <summary>
        /// 順位表+選手結合テーブル取得
        /// </summary>
        /// <returns>結果</returns>
        List<LeaderBoardAndPlayersDto> LeaderBoardAndPlayers();
    }
}
