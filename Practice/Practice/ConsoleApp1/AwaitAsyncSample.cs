using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class AwaitAsyncSample
    {
        public async void SampleAsync()
        {
            string text = "実行中";
            Console.WriteLine(text);

            await Task.Delay(3000);

            text = "完了";

            Console.WriteLine(text);

            Console.ReadKey();
        }

        public void Excute()
        {
            CancellationTokenSource source = new CancellationTokenSource();

            Console.WriteLine("Start");

            Task.Run(async delegate
            {
                while (true)
                {
                    if (source.Token.IsCancellationRequested)
                    {
                        // 2回目
                        Console.WriteLine("stop");
                        source.Dispose();
                        break;
                    }
                    // 1回目
                    source.Cancel();

                    Console.WriteLine("delay&&10Second");
                    for (int i = 1; i < 10; i++)
                    {
                        await Task.Delay(1000);
                        Console.WriteLine(i);
                    }
                }
            });

            Console.WriteLine("end");

            Console.ReadKey();
        }
    }
}
