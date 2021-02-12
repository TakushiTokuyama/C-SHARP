using System;
using System.Collections.Generic;
using System.Text;

namespace C_SHARP_7._0
{
    class DeconstructionSample
    {
        public void Execute() 
        {
            // 分解　Deconstruction
            var NameAndAge = (name: "Toku", age: 1122);
            string name;
            int age;
            (name, age) = NameAndAge;

            Console.WriteLine($"{name}And{age}");
        }

        public void Greeting(string name) 
        {
            var greets = (morning: "おはよう", noon: "こんにちは", night: "こんばんは");

            var nowTime = int.Parse(DateTime.Now.ToString("HH"));

            if (10 > nowTime && nowTime > 4)
            {
                Console.WriteLine(greets.morning);
            }
            else if (15 > nowTime && nowTime >= 10)
            {
                Console.WriteLine(greets.noon);
            }
            else 
            {
                Console.WriteLine(greets.night);
            }
        }
    }
}
