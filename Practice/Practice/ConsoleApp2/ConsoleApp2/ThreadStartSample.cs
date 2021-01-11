using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class ThreadStartSample
    {
        public void Main1()
        {
            Thread thread = new Thread(Dowork);

            thread.Start();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("In main.");
                Thread.Sleep(100);
            }
        }

        public void Dowork()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Working thread....");
                Thread.Sleep(100);
            }
        }

        public void Main2()
        {
            var flag = true;
            while (flag)
            {
                var num = int.Parse(Console.ReadLine());

                if (num < 0 && 4 < num)
                {
                    flag = false;
                    break;
                }

                Thread thread = new Thread(TotalNumber);
                thread.Start(num);

            }
        }

        public static int total = 0;

        public static void TotalNumber(object num)
        {
            total += Convert.ToInt32(num);

            if (total >= 3)
            {
                Console.WriteLine(total);
                for (int i = 1; i <= 10; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(i + "秒");
                }
                total = 0;
            }
        }
    }
}
