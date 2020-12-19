using System;
using System.Threading;

namespace ConsoleApp1
{
    public class ThreadSample
    {
        /// <summary>
        /// Thread
        /// </summary>
        public void Excute()
        {
            Thread thread = new Thread(new ThreadStart(() =>
            {
                CountUp1();
            }));

            thread.Start();

            CountUp2();
        }

        public void CountUp1() 
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(300);
                Console.WriteLine("countUp1が呼ばれました。");
            }
        }

        public void CountUp2() 
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("countUp2が呼ばれました。");
            }
        }
    }
}
