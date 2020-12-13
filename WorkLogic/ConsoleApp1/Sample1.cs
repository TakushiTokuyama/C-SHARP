using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Sample1
    {
        List<string> alphabet = new List<string>()
            {
                {"AAA"},{"BBB"},{"CCC"},{"DDD"},
                {"KK"},{"SSS"},{"SDS"},{"YYY"},{"DDD"}
            };

        public string[] alphabetView = new string[2];

        public void Logic()
        {
            for (int i = 0; i < 8; i++)
            {
                if (i > 3)
                {
                    alphabetView[1] += alphabet[i] + " ";
                    continue;
                }
                alphabetView[0] += alphabet[i] + " ";
            }

            if (alphabet.Count > 8)
            {
                alphabetView[1] = alphabetView[1].Replace(alphabet[7], "*");
            }

            Console.WriteLine(alphabetView[0]);
            Console.WriteLine(alphabetView[1]);
        }
    }
}
