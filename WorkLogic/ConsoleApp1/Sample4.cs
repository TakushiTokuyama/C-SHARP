using System;
using System.Linq;

namespace ConsoleApp1
{
    public class Sample4
    {
        public void Logic()
        {
            string result = "0";

            string num = "A999";

            string numFirst = num.Substring(0, 1);

            int numLast = int.Parse(num.Substring(1, 3));

            string language = "123456789ABCDEFGHIJKLNMOPQRSTUVWXYZ";

            string[] languageList = language.Split(',');

            if (numLast == 999)
            {
                foreach (var item in language)
                {
                    if (numFirst.ToCharArray().First() == 'Z')
                    {
                        numFirst = "1";

                        result = numFirst + "001";

                        break;
                    }

                    if (item == numFirst.ToCharArray().First())
                    {
                        var i = language.IndexOf(item);

                        i++;

                        numFirst = language[i].ToString();

                        result = numFirst + "001";

                        break;
                    }
                }
            }
            else
            {
                numLast++;
                result = numFirst + string.Format("{0:D3}", numLast);
            }

            Console.WriteLine(result);
        }
    }
}
