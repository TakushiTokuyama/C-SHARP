using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using BB001.Model;

namespace BB001
{
    /// <summary>
    /// OracleDbConnection(接続設定)　クラス
    /// </summary>
    public class OracleDbConnection
    {
        /// <summary>
        /// OracleDb接続後検索(LeaderBoardTable)
        /// </summary>
        /// <returns>LeaderBoardTableList</returns>
        public List<LeaderBoard> FindLeaderBoard(List<LeaderBoard> list)
        {
            try
            {
                var conn = GetOracleConnection();
                // 接続
                conn.Open();

                OracleDbSql sql = new OracleDbSql();

                var reader = getOracleDataReader(conn, sql.FindAllLeaderBoard);

                // 読み込み
                while (reader.Read()) 
                {
                    // Model詰替え
                    FindLeaderBoard(reader, list);
                }

                // 接続終了
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "LEADERBOARD");
            }

            return list;
        }

        /// <summary>
        /// OracleDb接続後検索(LeaderBoardTable)
        /// </summary>
        /// <returns>LeaderBoardTableList</returns>
        public List<BbPlayers> FindBbPlayers(List<BbPlayers> list)
        {
            try
            {
                var conn = GetOracleConnection();
                // 接続
                conn.Open();

                OracleDbSql sql = new OracleDbSql();

                var reader = getOracleDataReader(conn, sql.FindAllBbPlayers);

                // 読み込み
                while (reader.Read())
                {
                    // Model詰替え
                    FindBbPlayers(reader, list);
                }

                // 接続終了
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "BBPLAYERS");
            }

            return list;
        }



        private OracleConnection GetOracleConnection() 
        {
            OracleDbConnectionInfo connectionInfo = new OracleDbConnectionInfo();

            OracleConnection conn = new OracleConnection(connectionInfo.getConnectionInfo());

            return conn;
        }

        private OracleDataReader getOracleDataReader(OracleConnection conn, string sql) 
        {
            OracleCommand cmd = new OracleCommand(sql, conn);

            // SQL実行
            var reader = cmd.ExecuteReader();

            return reader;
        }

        private void FindLeaderBoard(OracleDataReader reader,  List<LeaderBoard> leaderBoardList) 
        {
            var teamid = int.Parse(reader.GetValue(0).ToString());
            var teamName = reader.GetValue(1).ToString();
            var matche = int.Parse(reader.GetValue(2).ToString());
            var win = int.Parse(reader.GetValue(3).ToString());
            var lose = int.Parse(reader.GetValue(4).ToString());
            var draw = int.Parse(reader.GetValue(5).ToString());

            leaderBoardList.Add(new LeaderBoard
            {
                TeamId = teamid,
                TeamName = teamName,
                Matche = matche,
                Win = win,
                Lose = lose,
                Draw = draw
            });
        }

        private void FindBbPlayers(OracleDataReader reader, List<BbPlayers> bbPlayersList)
        {          
            var id = int.Parse(reader.GetValue(0).ToString());
            var teamid = int.Parse(reader.GetValue(1).ToString());
            var countryId = int.Parse(reader.GetValue(2).ToString());
            var uniformNum = int.Parse(reader.GetValue(3).ToString());
            var position = reader.GetValue(4).ToString();
            var name = reader.GetValue(5).ToString();
            var birth = DateTime.Parse(reader.GetValue(6).ToString());
            var height = int.Parse(reader.GetValue(7).ToString());
            var weight = int.Parse(reader.GetValue(8).ToString());

            bbPlayersList.Add(new BbPlayers
            {
                Id = id,
                TeamId = teamid,
                CountryId = countryId,
                UniformNum = uniformNum,
                Position = position,
                Name = name,
                Birth = birth,
                Height = height,
                Weight = weight
            });
        }
    }
}
