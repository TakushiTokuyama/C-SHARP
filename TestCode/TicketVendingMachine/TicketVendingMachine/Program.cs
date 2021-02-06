using System;

namespace TicketVendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            // 処理開始
            Console.WriteLine("処理開始");

            var vendingService = new VendingService();

            // メイン処理
            vendingService.Execute();

            // 処理終了
            Console.WriteLine("処理終了");
        }
    }
}
