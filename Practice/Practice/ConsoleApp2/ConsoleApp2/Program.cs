using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program 
    { 

        static bool th = false;

        static void Main(string[] args)
        {
            string result = "";

            
            Thread thread = new Thread(new ThreadStart(() =>
            {
                result = HeavyMethod();
            }));

            thread.Start();

            th = true;

            thread.Join(10000);

            Console.WriteLine(result);

            Console.ReadLine();
        }
        static string HeavyMethod()
        {
            Console.WriteLine("1");
            Thread.Sleep(6000);
            if (th)
            {
                Console.WriteLine("2");
            }

            return "3";
        }
    }


}
