using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp3
{
    public class SampleLogic
    {
        /// <summary>
        /// 配列の文字列をソート
        /// </summary>
        public void Logic()
        {
            //配列
            var list = Enumerable.Repeat("a", 20).ToList();

            list.ForEach(o => Console.Write(o));

            var list2 = new List<string>
            {
                "AGH","D","B","F",null,"A","FG"
            };

            // nullを無視して長さ順にソート
            var list3 = list2.OrderBy(o => o == null ? 1 : 0).ThenBy(o => o).ToList();

            list3.ForEach(o => Console.WriteLine(o));
        }

        /// <summary>
        /// 配列とリストの複成後重複チェック
        /// </summary>
        public void Logic2() 
        {
            var list1 = new string[] { "A", "B", "C", "D", "D" };

            var list2 = new string[5];

            Array.Copy(list1, 0, list2, 0, 5);

            if (list2.Count() != list1.GroupBy(o => o).Count())
            {
                Console.WriteLine("重複あり");
            }
            else
            {
                Console.WriteLine("重複なし");
            }

            var list3 = new List<string> { "A", "B", "C", "E", "E" };

            var list4 = new List<string>();

            list4.AddRange(list3);

            if (list3.Count() != list4.GroupBy(o => o).Count())
            {
                Console.WriteLine("重複あり");
            }
            else
            {
                Console.WriteLine("重複なし");
            }
        }
    }
}
