namespace BB001
{
    /// <summary>
    /// OracleDbConnectionInfo(接続先情報)クラス
    /// </summary>
    public class OracleDbConnectionInfo
    {
        private const string connectionString = "Data Source=(DESCRIPTION =(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                                   "(Host = myoracle.cqsqewpv40rb.ap-northeast-1.rds.amazonaws.com)(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME = myoracle)));" +
                                   "User ID=admin;Password=11111111;";
        /// <summary>
        ///OracleDB 接続先情報取得
        /// </summary>
        /// <returns>接続先情報</returns>
        public string getConnectionInfo() 
        {
            return connectionString;
        }
    }
}
