using System;
using System.IO;

namespace sample01
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = string.Format("{0:yyyyMMdd}" + " " + "{1:hh:mm:ss}", DateTime.Today, DateTime.Now);

            Console.WriteLine(log);

            var filePath = Path.GetFileName(@"C:test\sample.txt");

            Console.WriteLine(filePath);
        }
    }
}
