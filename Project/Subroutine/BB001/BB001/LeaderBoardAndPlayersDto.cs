namespace BB001
{
    /// <summary>
    /// GetWinRateResponse
    /// </summary>
    public class LeaderBoardAndPlayersDto
    {
        public string TeamName { get; set; }

        /// <summary>
        /// 勝率
        /// </summary>
        public double WinRate { get; set; }

        /// <summary>
        /// 選手名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 順位表
        /// </summary>
        public int LeaderNum { get; set; }
    }
}
