using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /// <summary>
    /// NO4 重りと天秤
    /// </summary>
    public class NO4
    {
        /// <summary>
        /// NO4 重りと天秤
        /// </summary>
        public void Logic()
        {
            // 重りのサイズ配列
            int[] sizeList1 = { 1, 2, 3 };

            int[] sizeList2 = { 1, 2, 3, 4, 5 };

            int[] sizeList3 = { 62, 8, 90, 2, 24, 62, 38, 64, 76, 60, 30, 76, 80, 74, 72 };

            // 重りの合計重量
            int totalSize = 0;

            foreach (var item in sizeList2)
            {
                totalSize += item;
            }

            // 天秤
            if (totalSize % 2 == 0)
            {
                Console.WriteLine("possible");
            }
            else
            {
                Console.WriteLine("impossible");
            }
        }
    }
}
