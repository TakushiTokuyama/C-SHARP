using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /// <summary>
    /// NO.5 数字のブロック
    /// </summary>
    public class NO5
    {
        /// <summary>
        /// No.5 数字のブロック
        /// </summary>
        public void Logic()
        {
            // 箱のサイズ
            int boxSize = int.Parse(Console.ReadLine());

            // 小さい箱のサイズリスト
            int[] boxSmallSizeList1 = { 10, 5, 7 };

            int[] boxSmallSizeList2 = { 14, 85, 77, 26, 50, 45, 66, 79, 10, 3 };

            int count = 0;

            int max = 0;

            // 小さい箱のサイズをソートする
            Array.Sort(boxSmallSizeList2);

            foreach (var item in boxSmallSizeList2)
            {
                max += item;

                if (max > boxSize)
                {
                    break;
                }

                count++;
            }

            Console.WriteLine(count);
        }
    }
}
