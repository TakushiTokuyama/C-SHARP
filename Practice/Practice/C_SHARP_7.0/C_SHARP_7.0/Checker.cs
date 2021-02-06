using System;
using System.Collections.Generic;
using System.Text;

namespace C_SHARP_7._0
{
    public class Checker
    {
        /// <summary>
        /// 型チェック
        /// </summary>
        /// <param name="o"></param>
        public void isTypeCheck(Object o )
        {
            if (o is int)
            {
                Console.WriteLine("int");
            }

            if(o is string)
            {
                Console.WriteLine("string");
            }

            if (o is null) 
            {
                Console.WriteLine("null");
            }
        }
    }
}
