using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class No2
    {
        public void Logic()
        {
            var input = Console.ReadLine();

            // 素因数チェック
            int count = 0;

            for (int i = 1; i < int.Parse(input) + 1; i++)
            {
                if (int.Parse(input) % i == 0)
                {
                    count++;
                }
            }

            if (count == 2)
            {
                Console.WriteLine("{0}は素因数です。", input);
            }
            else
            {
                Console.WriteLine("{0}は素因数ではない。", input);
            }

            int N = int.Parse(Console.ReadLine());
            List<int> numList = new List<int>();

            // 約数を調べる
            for (int i = 1; i < N + 1; i++)
            {
                if (N % i == 0)
                {
                    numList.Add(i);
                }
            }


            List<int> numList1 = new List<int>();

            // 素因数を調べる
            foreach (var item in numList)
            {
                // 初期化
                count = 0;

                for (int i = 1; i < item + 1; i++)
                {
                    if (item % i == 0)
                    {
                        count++;
                    }
                }

                if (count == 2)
                {
                    numList1.Add(item);
                }
            }

            foreach (var item in numList1)
            {
                Console.WriteLine(item);
            }
        }
    }
}
