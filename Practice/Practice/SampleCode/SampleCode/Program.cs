using SampleCode;
using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {

            // var result = new ExchangeConverter(new EuroConverter(), new DollerConverter()).Convert(100);

            // Console.WriteLine(result);

            // new AppServiceProvider().Register();

            new Country<Japan>();
            new Country<USA>();


            new TestMail(new User() { id = 1, Name = "A", Token = "222" });
        }
    }
}
