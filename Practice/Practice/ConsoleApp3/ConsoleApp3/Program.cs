using System;
using System.Linq;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string dir = "D:test\\test2\\";

            DateTime day = DateTime.Now;

            string file = "\\test.txt";

            string filePath = $@"{dir}{day.ToString("yyyyMMdd")}{file}";

            Console.WriteLine(filePath);
        }
    }
}
