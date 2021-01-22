using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class ClockThread
    {
        /// <summary>
        /// 実行クラス
        /// </summary>
        public void Execute() 
        {
            // TimerCallback timer = new TimerCallback(Clock);

            ClockThread clockThread = new ClockThread();

            clockThread.StartTimer(5000);
            clockThread.EndTimer(1000);

            Console.WriteLine("Press Enter to end the program.");
            Console.ReadLine();

        }

        public void StartTimer(int dueTime) 
        {
                Timer t = new Timer(new TimerCallback(TimerProc));
                t.Change(dueTime, 0);
        }

        public void EndTimer(int dueTime)
        {
            Timer t = new Timer(new TimerCallback(TimerProc1));
            t.Change(dueTime, 0);
        }

        private void TimerProc1(object state)
        {
            Timer t = (Timer)state;
            t.Dispose();
            Console.WriteLine("1");
        }

        private void TimerProc(object state)
        {
            Timer t = (Timer)state;
            t.Dispose();
            Console.WriteLine("The timer callback executes.");
        }


        /// <summary>
        /// 現在時刻を表示
        /// </summary>
        private void Clock(object o) 
        {
            Console.WriteLine(DateTime.Now);
        }
    }
}
