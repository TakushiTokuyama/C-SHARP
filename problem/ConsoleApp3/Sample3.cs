using System;
using System.Collections.Generic;
using System.Linq;


namespace ConsoleApp3
{
    // Contains
    public class Sample3
    {
        /// <summary>
        /// 要素が存在するか調べる
        /// </summary>
        public void Logic1()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            bool resultA = numbers.Contains(8);
            bool resultB = numbers.Contains(3);
            bool resultC = numbers.Contains(12);

            Console.WriteLine("numbers:{0}", numbers.Text());
            Console.WriteLine("8の要素はありますか：{0}", resultA);
            Console.WriteLine("3の要素はありますか：{0}", resultB);
            Console.WriteLine("12の要素はありますか：{0}", resultC);
        }
        
        private class Parameter
        {
            public int ID { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return string.Format("ID:{0}, Name:{1}", ID, Name);
            }
        }
        
        /// <summary>
        /// 参照型の要素を調べる
        /// </summary>
        public void Logic2() 
        {
            List<Parameter> parameters = new List<Parameter>();

            Parameter valueA = new Parameter() { ID = 0, Name = "正一郎" };
            Parameter valueB = new Parameter() { ID = 5, Name = "清次郎" };
            Parameter valueC = new Parameter() { ID = 3, Name = "誠三郎" };
            Parameter valueD = new Parameter() { ID = 9, Name = "征史郎" };

            parameters.Add(valueA);
            parameters.Add(valueB);
            parameters.Add(valueC);

            bool reaultA = parameters.Contains(valueA);
            bool reaultB = parameters.Contains(valueC);
            bool reaultC = parameters.Contains(valueD);

            System.Console.WriteLine("parameters:{0}", parameters.Text());
            System.Console.WriteLine("正一郎の要素はありますか:{0}", reaultA);
            System.Console.WriteLine("誠三郎の要素はありますか:{0}", reaultB);
            System.Console.WriteLine("征史郎の要素はありますか:{0}", reaultC);

        }
    }
}
