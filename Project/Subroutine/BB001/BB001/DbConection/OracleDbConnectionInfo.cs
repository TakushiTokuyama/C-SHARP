using BB001.DbConection;

namespace BB001
{
    /// <summary>
    /// OracleDbConnectionInfo(接続先情報)クラス
    /// </summary>
    public class OracleDbConnectionInfo
    {
        private string connectionString = ConstConnection.ConnectionInfo;
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
