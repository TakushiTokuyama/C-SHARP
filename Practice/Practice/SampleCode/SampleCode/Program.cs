using SampleCode;
using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var result = new ExchangeConverter(new EuroConverter(), new DollerConverter()).Convert(100);

            Console.WriteLine(result);
        }
    }
}
