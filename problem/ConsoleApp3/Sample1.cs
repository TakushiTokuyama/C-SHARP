using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp3
{
    class Sample1
    {
        /// <summary>
        /// 配列の中身を2倍にする
        /// </summary>
        public void Logic1()
        {
            int[] numbers = { 1, 2, 4, 7, 9, 32, 54 };

            // 全ての数値を2倍する
            IEnumerable<int> result = numbers.Select(n => n * 2);

            // 表示フォーマット
            string text = string.Empty;
            foreach (int value in result)
            {
                text += string.Format("{0}, ", value);
            }
            //表示
            Console.WriteLine(text);
        }
        /// <summary>
        /// 数値をstring型に
        /// </summary>
        public void Logic2()
        {
            int[] numbers = { 1, 4, 7, 12, 15 };

            // 全ての数値を"{数字}"のフォーマットの文字列に変換する
            IEnumerable<string> result = numbers.Select(n => string.Format("[{0}]", n.ToString("D2")));

            // 表示用文字列
            string text = string.Empty;
            foreach (var value in result)
            {
                text += string.Format("{0}, ", value);

                Console.WriteLine(text);
            }
        }

        // Logic3,Logic4用Parameter
        private class Parameter
        {
            public int ID { get; set; }
            public float Rate { get; set; }
            public string Name { get; set; }
        }

        /// <summary>
        /// 特定のプロパティだけにする
        /// </summary>
        public void Logic3()
        { 
            Parameter[] parameters = new Parameter[]
            {
                new Parameter { ID = 5,  Rate = 0.0f, Name = "正一郎" },
                new Parameter { ID = 13, Rate = 0.1f, Name = "清次郎" },
                new Parameter { ID = 25, Rate = 0.0f, Name = "誠三郎" },
                new Parameter { ID = 42, Rate = 0.3f, Name = "征史郎" },
            };

            // Nameのプロパティのみを抜き取る
            IEnumerable<string> result = parameters.Select(p => p.Name);

            // 表示用
            string text = string.Empty;
            foreach (var value in result)
            {
                text += string.Format("{0}, ", value);
            }

            Console.WriteLine(text);
        }

        /// <summary>
        /// 複数のプロパティ
        /// </summary>
        public void Logic4() 
        {
            Parameter[] parameters = new Parameter[]
        {
            new Parameter { ID =  5, Rate = 0.0f, Name = "正一郎" },
            new Parameter { ID = 13, Rate = 0.1f, Name = "清次郎" },
            new Parameter { ID = 25, Rate = 0.0f, Name = "誠三郎" },
            new Parameter { ID = 42, Rate = 0.3f, Name = "征史郎" },
        };

            //IDの2倍の値とNameのプロパティのみを抜き取って、匿名型に変換する
            var result = parameters.Select(p => new { Number = p.ID * 2, p.Name});

            // 表示用の文字列
            string text = string.Empty;
            foreach (var value in result)
            {
                text += string.Format("[{0}]:{1} ", value.Number, value.Name);
            }

            Console.WriteLine(text);
        }

        /// <summary>
        /// インデックス取得
        /// </summary>
        public void Logic5()
        {
            string[] names = new string[] { "正一郎", "清次郎", "誠三郎", "征史郎" };

            // 表示用の文字列
            string text = string.Empty;

            for (int i = 0; i < names.Length; i++)
            {
                text += string.Format("[{0}]:{1}, ", i, names[i]);
            }

            Console.WriteLine(text);
        }

        /// <summary>
        /// インデックス取得 linq
        /// </summary>
        public void Logic6()
        {
            string[] names = new string[] { "正一郎", "清次郎", "誠三郎", "征史郎" };

            // 配列のインデックスと名前を取得、匿名型に変換する。
            // 二弁目の引数に配列のインデックスが入ってくる。

            var result = names.Select((value, index) => new { Number = index, Name = value });


            // 表示用の文字列
            string text = string.Empty;

            foreach (var value in result)
            {
                text += string.Format("[{0}]:{1}", value.Number, value.Name);
            }

            Console.WriteLine(text);
        }

        private class Parameter7
        {
            public string Name { get; set; }
            public int[] Numbers { get; set; }
        }

        /// <summary>
        /// 平坦化
        /// </summary>
        public void Logic7()
        {
            Parameter7[] parameters = new Parameter7[]
        {
            new Parameter7 { Name = "正一郎", Numbers = new int[] { 1, 2, 3 } },
            new Parameter7 { Name = "清次郎", Numbers = new int[] { 1, 3, 5 } },
            new Parameter7 { Name = "誠三郎", Numbers = new int[] { 2, 4, 6 } },
            new Parameter7 { Name = "征史郎", Numbers = new int[] { 9, 8, 7 } },
        };

            IEnumerable<int> result = parameters.SelectMany(r => r.Numbers);

            // 表示用の文字列
            string text = string.Empty;

            foreach (var value in result)
            {
                text += string.Format("{0}, ", value);
            }

            Console.WriteLine(text);

        }

        // 8,9
        private class Parameter8
        {
            public string Name { get; set; }
            public int[] Numbers { get; set; }
        }

        /// <summary>
        /// 平坦化後、インデックス取得
        /// </summary>
        public void Logic8()
        {
            Parameter8[] parameters = new Parameter8[]
            {
            new Parameter8 { Name = "正一郎", Numbers = new int[] { 1, 2, 3 } },
            new Parameter8 { Name = "清次郎", Numbers = new int[] { 1, 3, 5 } },
            new Parameter8 { Name = "誠三郎", Numbers = new int[] { 2, 4, 6 } },
            new Parameter8 { Name = "征史郎", Numbers = new int[] { 9, 8, 7 } },
            };
            
            // Parameter8の配列のインデックスをIndexAに、Numbersの配列のインデックスをIndexBに
            var results = parameters.SelectMany((value, indexA) =>
                               value.Numbers.Select((number, indexB) =>
                                new { Number = number, IndexA = indexA, IndexB = indexB }));

            // 表示用の文字列作成
            string text = string.Empty;

            foreach (var value in results)
            {
                text += string.Format("[{0}:{1}]{2}, ", value.IndexA, value.IndexB, value.Number);
            }

            System.Console.WriteLine(text);
        }

        /// <summary>
        /// 平坦化　Name+Number
        /// </summary>
        public void Logic9()
        {
            Parameter8[] parameters = new Parameter8[]
            {
            new Parameter8 { Name = "正一郎", Numbers = new int[] { 1, 2, 3 } },
            new Parameter8 { Name = "清次郎", Numbers = new int[] { 1, 3, 5 } },
            new Parameter8 { Name = "誠三郎", Numbers = new int[] { 2, 4, 6 } },
            new Parameter8 { Name = "征史郎", Numbers = new int[] { 9, 8, 7 } },
            };

            // 平坦化後、NameとNumber
            var results = parameters.SelectMany(param => param.Numbers,
                                                    (value, number) => new { value.Name, number });

            // 表示用の文字列作成
            string text = string.Empty;

            foreach (var value in results)
            {
                text += string.Format("[{0}:{1}], ", value.Name, value.number);
            }

            System.Console.WriteLine(text);

        }
        /// <summary>
        /// インデックス
        /// </summary>
        public void Logic10()
        {
            Parameter8[] parameters = new Parameter8[]
            {
            new Parameter8 { Name = "正一郎", Numbers = new int[] { 1, 2, 3 } },
            new Parameter8 { Name = "清次郎", Numbers = new int[] { 1, 3, 5 } },
            new Parameter8 { Name = "誠三郎", Numbers = new int[] { 2, 4, 6 } },
            new Parameter8 { Name = "征史郎", Numbers = new int[] { 9, 8, 7 } },
            };

            // 平坦化後、Number,Index
            var results = parameters.SelectMany((value, IndexA) =>
                                                    value.Numbers.Select((number, IndexB) =>
                                                        new { number, IndexA, IndexB }),
                                                            (value, param) => new { value.Name, param });

            // 表示用の文字列作成
            string text = string.Empty;

            foreach (var value in results)
            {
                text += string.Format("[{0}:{1}]{2}, ", value.param.IndexA, value.param.IndexB, value.Name);
            }

            System.Console.WriteLine(text);
        }
    }
}
