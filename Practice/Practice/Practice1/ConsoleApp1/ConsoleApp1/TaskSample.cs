using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// Task
    /// </summary>
    public class TaskSample
    {
        public void Excute()
        {
            Task task = Task.Run(() =>
            {
                CountUp1();
            });

            task.Wait();

            CountUp2();
        }

        public void CountUp1()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("countUp1が呼ばれました。");
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
