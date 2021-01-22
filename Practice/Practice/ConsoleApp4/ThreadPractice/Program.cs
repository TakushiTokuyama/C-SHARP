using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class ThreadTimerTest
    { 
        public void Run()
        {
            TimerCallback timerCallback = new TimerCallback(MyClock);
            Timer timer = new Timer(timerCallback, null, 0, 1000);

            // 10秒停止d
            Thread.Sleep(10000);


            // 停止
            timer.Change(Timeout.Infinite, Timeout.Infinite);

            timer.Dispose();
        }

        public void MyClock(object o)
        {
            Console.WriteLine(DateTime.Now);
        }
    }
        class Program
    {
        static void Main(string[] args)
        {
            ClockThread clockThread = new ClockThread();

            clockThread.Execute();

            //var test = new ThreadTimerTest();

            //while (true)
            //{
            //    var watcher = new System.IO.FileSystemWatcher();

            //    watcher.Path = @"D:\sample";

            //    watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName;

            //    watcher.Filter = "*.txt";

            //    watcher.IncludeSubdirectories = true;

            //    watcher.Created += Changed;
            //    watcher.Changed += Changed;
            //    watcher.Deleted += Changed;
            //    watcher.Renamed += Changed;

            //    watcher.EnableRaisingEvents = true;

            //    test.Run();
            //}
        }

        public static void Changed(object source, FileSystemEventArgs e)
        {
            switch (e.ChangeType)
            {
                case WatcherChangeTypes.Created:
                    Console.WriteLine($"新規作成: {e.FullPath}");
                    break;
                case WatcherChangeTypes.Deleted:
                    Console.WriteLine($"削除: {e.FullPath}");
                    break;
                case WatcherChangeTypes.Changed:
                    Console.WriteLine($"変更: {e.FullPath}");
                    break;
                case WatcherChangeTypes.Renamed:
                    var renameEventArgs = e as RenamedEventArgs;
                    Console.WriteLine($"リネーム: {renameEventArgs.OldFullPath} => {renameEventArgs.FullPath}");
                    break;
            }
        }
    }
}
