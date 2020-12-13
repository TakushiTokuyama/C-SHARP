using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /// <summary>
    /// NO7 プライムナンバーゲーム
    /// </summary>
    public class NO7
    {
        /// <summary>
        /// プライムナンバーゲーム
        /// </summary>
        public void Logic()
        {
            int N = int.Parse(Console.ReadLine());

            int[] numbers = new int[N - 1];

            // N以下の数を生成
            for (int i = 0; i < N - 1; i++)
            {
                numbers[i] = i + 1;
            }

            List<int> numbersList = new List<int>();
            foreach (var item in numbers)
            {
                int count = 0;

                for (int i = 1; i <= item; i++)
                {
                    if (item % i == 0)
                    {
                        count++;
                    }
                }

                if (count == 2)
                {
                    numbersList.Add(item);
                }
            }

            foreach (var item in numbersList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
