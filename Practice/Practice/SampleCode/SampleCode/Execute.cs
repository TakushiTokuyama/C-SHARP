using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Execute
    {
        /// <summary>
        /// Connection取得サンプル
        /// </summary>
        public void getConnectionExecute() 
        {
            // IReadOnlyList
            foreach (var connection in ConnectionList.getConnectionList())
            {
                Console.WriteLine(connection);
            }

            // IReadOnlyDictionary
            for (int i = 1; i <= ConnectionList.GetConnectionKeyValues().Count; i++)
            {
                Console.WriteLine(ConnectionList.GetConnectionKeyValues()[i.ToString()]);
            }

            // IReadOnlyCollection
            foreach (var collection in ConnectionList.GetConnectionCollectionList())
            {
                Console.WriteLine(collection);
            }
        }
    }
}
