using System;
using System.Collections.Generic;
using System.Text;

namespace BB001.Model
{
    /// <summary>
    /// BbPlayersTable
    /// </summary>
    public class BbPlayers
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// チームID
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// 国ID
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// 背番号
        /// </summary>
        public int UniformNum { get; set; }

        /// <summary>
        /// ポジション
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// 選手名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 誕生日
        /// </summary>
        public DateTime Birth { get; set; }

        /// <summary>
        /// 身長
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 体重
        /// </summary>
        public int Weight { get; set; }


    }
}
