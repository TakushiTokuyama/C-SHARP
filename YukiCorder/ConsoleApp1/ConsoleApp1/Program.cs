using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int P = int.Parse(Console.ReadLine());

            int N = int.Parse(Console.ReadLine());

            int K = int.Parse(Console.ReadLine());

            int result = 0;

            Console.WriteLine(20 % 4);

            // 最後にK - 1を足して相手に渡せば勝利 
            if (result == N - K - 1) {
                result += K;
            }
        }
    }
}
