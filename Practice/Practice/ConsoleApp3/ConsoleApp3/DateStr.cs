using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class DateStr
    {
        public void Sample()
        {
            string dir = "D:test\\test2\\";

            DateTime day = DateTime.Now;

            string file = "\\test.txt";

            string filePath = $@"{dir}{day.ToString("yyyyMMdd")}{file}";

            Console.WriteLine(filePath);
        }
    }
}
