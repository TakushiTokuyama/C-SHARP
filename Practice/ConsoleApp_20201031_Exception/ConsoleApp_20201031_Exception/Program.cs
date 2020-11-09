using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp_20201031_Exception
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string> { "A", "B", "C" };
            Console.WriteLine(list[0]);

           

            List<string> A = null;
            Console.WriteLine(A[0]);
        }
    }
}
