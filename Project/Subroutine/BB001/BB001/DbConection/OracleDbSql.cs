namespace BB001
{
    /// <summary>
    /// OracleDbSql(SQL記述)　クラス
    /// </summary>
    public class OracleDbSql
    {
        /// <summary>
        /// LeaderBoardTable 全件検索
        /// </summary>
        public string FindAllLeaderBoard = "SELECT * FROM LEADERBOARD";

        /// <summary>
        /// BbPlayersTable 全件検索
        /// </summary>
        public string FindAllBbPlayers = "SELECT * FROM BBPLAYERS";
    }
}
