using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp1
{
   public class NO6
    {
        public void Logic()
        {
            // 最小値
            int minNum = int.Parse(Console.ReadLine());
            // 最大値
            int maxNum = int.Parse(Console.ReadLine());

            List<int> primeNumbers = new List<int>();

            for (; minNum <= maxNum; minNum++)
            {
                int count = 0;

                for (int i = 1; i <= minNum; i++)
                {
                    if (minNum % i == 0)
                    {
                        count++;
                    }
                }

                // 素数をHashに置換して格納
                if (count == 2)
                {
                    // 一桁
                    if (minNum.ToString().Length == 1)
                    {
                        primeNumbers.Add(minNum);
                    }

                    // 二桁
                    if (minNum.ToString().Length == 2)
                    {
                        int hashNum = minNum / 10 + minNum % 10;

                        if (hashNum > 9)
                        {
                            primeNumbers.Add(hashNum / 10 + hashNum % 10);
                        }
                        else
                        {
                            primeNumbers.Add(minNum / 10 + minNum % 10);
                        }
                    }
                }
            }

            // 重複除去
            var groupByPrimeNumbers = primeNumbers.GroupBy(n => n).Select(n => new { n.Key });

            int sum = groupByPrimeNumbers.Count();

            // コピー配列
            int[] primeNumbers1 = new int[primeNumbers.Count()];

            int x = 0;

            foreach (var item in primeNumbers)
            {
                primeNumbers1[x] = item;
                x++;
            }

            int firstValue = 0;

            int total = 0;

            Size size = new Size();

            size.sizeList = null;

            List<int> groupByMaxColumnPrimeNumbers = new List<int>();

            foreach (var item in primeNumbers)
            {
                int count = 1;

                firstValue = item;

                // 初期化
                groupByMaxColumnPrimeNumbers = new List<int>();

                for (int i = 0; total <= primeNumbers1.Length; i++)
                {
                    groupByMaxColumnPrimeNumbers.Add(primeNumbers[i + total]);

                    var groupByCount = groupByMaxColumnPrimeNumbers.GroupBy(p => p).Select(p => p.Key);

                    if (count != groupByCount.Count())
                    {
                        break;
                    }

                    if (count == groupByMaxColumnPrimeNumbers.Count())
                    {
                        size.sizeList = groupByMaxColumnPrimeNumbers;
                        break;
                    }

                    count++;
                }

                if (count == groupByPrimeNumbers.Count())
                {
                    break;
                }
            }

            Console.WriteLine(firstValue);

            foreach (var item in size.sizeList)
            {
                Console.WriteLine(item);
            }
        }

        public class Size
        {
            public int total { get; set; }
            public List<int> sizeList { get; set; }
        }
    }
}
