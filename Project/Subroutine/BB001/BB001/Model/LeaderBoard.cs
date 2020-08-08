namespace BB001.Model
{
    /// <summary>
    /// LeaderBoardTable
    /// </summary>
    public class LeaderBoard
    {
        /// <summary>
        /// チームID
        /// </summary>
        public int TeamId { get; set; }
        /// <summary>
        /// チーム名
        /// </summary>
        public string TeamName { get; set; }

        /// <summary>
        /// 試合
        /// </summary>
        public int Matche { get; set; }

        /// <summary>
        /// 勝利
        /// </summary>
        public int Win { get; set; }

        /// <summary>
        /// 負け
        /// </summary>
        public int Lose { get; set; }

        /// <summary>
        /// 引き分け
        /// </summary>
        public int Draw{get;set;}

        /// <summary>
        /// 勝率
        /// </summary>
        public double WinRate { get; set; }

        /// <summary>
        /// 順位
        /// </summary>
        public int LeaderNum { get; set; }
    }
}
