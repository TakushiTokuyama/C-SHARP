using BB001.Model;
using System.Collections.Generic;
using System.Linq;

namespace BB001
{
    /// <summary>
    /// B001Service
    /// </summary>
    public class BB001Service : IBB001Service
    {
        /// <inheritdoc />
        public List<LeaderBoardAndPlayersDto> LeaderBoardAndPlayers()
        {
            OracleDbConnection oracleDbConnection = new OracleDbConnection();

            var leaderBoard = oracleDbConnection.FindLeaderBoard(new List<LeaderBoard>());

            leaderBoard.ForEach(l =>
            {
                l.WinRate = l.Win / (double)(l.Win + l.Lose);
            });

            var sortLB = leaderBoard.OrderByDescending(l => l.WinRate).ToList();

            foreach (var item in Enumerable.Range(1, sortLB.Count()))
            {
                sortLB[item - 1].LeaderNum = item;
            }

            var bbPlayers = oracleDbConnection.FindBbPlayers(new List<BbPlayers>());

            var LBBPlayers = leaderBoard.Join(bbPlayers,
                l => l.TeamId,
                p => p.TeamId,
                (l, p) => new LeaderBoardAndPlayersDto
                {
                    TeamName = l.TeamName,
                    WinRate = l.Win / (double)(l.Win + l.Lose),
                    Name = p.Name,
                    LeaderNum = l.LeaderNum

                }).OrderByDescending(l => l.WinRate);

            LBBPlayers = null;

            if (LBBPlayers == null)
            {
                return new List<LeaderBoardAndPlayersDto>();
            }

            return LBBPlayers.ToList();
        }
    }
}
