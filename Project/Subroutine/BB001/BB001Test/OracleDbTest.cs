using BB001;
using Xunit;

namespace BB001Test
{
    public class BB001OracleDbTest
    {
        private readonly OracleDbSql _oracleDbSql;

        public BB001OracleDbTest()
        {
            //準備
            _oracleDbSql = new OracleDbSql();
        }

        [Fact]
        public void BBPLAYSERSテーブルを全件検索できるSELECT文が書かれていること()
        {

            // 実行&検証
            Assert.Equal("SELECT * FROM LEADERBOARD", _oracleDbSql.FindAllLeaderBoard);
        }
    }
}
