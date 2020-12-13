using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "20190604";

            var text = string.Format($"yymmdd", str);

            Console.WriteLine(text);
        }
    }
}
