using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    /// <summary>
    /// 接続先リスト
    /// </summary>
    public class ConnectionList
    {
        private static List<string> list = new List<string> { "TypeA", "TypeB", "TypeC" };

        private static Dictionary<string, string> dictinaryList = new Dictionary<string, string> { {"1","TypeA"},{"2","TypeB" },{"3","TypeC" } };

        private static IReadOnlyCollection<string> CollectionList = new List<string> { "TypeA", "TypeB", "TypeC" };

        /// <summary>
        /// 接続先を取得 IReadOnlyList
        /// </summary>
        public static IReadOnlyList<string> getConnectionList()
        {
            return list.AsReadOnly();
        }

        /// <summary>
        /// 接続先を取得 IReadOnlyDictionary
        /// </summary>
        /// <returns></returns>
        public static IReadOnlyDictionary<string, string> GetConnectionKeyValues()
        {
            return dictinaryList;
        }

        /// <summary>
        /// 接続先を取得 IReadOnlyCollection
        /// </summary>
        /// <returns></returns>
        public static IReadOnlyCollection<string> GetConnectionCollectionList()
        {
            return CollectionList;
        }
    }
}
