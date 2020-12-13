using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    // 例外
    public class Exception1
    {
        /// <summary>
        /// 例外処理
        /// </summary>
        public void Logic1()
        {
            List<string> nameList = new List<string>()
            {
                "suzuki", "tanaka", "satou", "JaiAn"
            };

            Dictionary<string, int> ZaikoList = new Dictionary<string, int>()
            {
                { "リンゴ", 4 },
                { "オレンジ", 2 },
                { "ピーチ", 3}
            };

            void BuyFruits(int num, string fruits)
            {
                try
                {
                    // エラーチェック
                    if (!ZaikoList.ContainsKey(fruits))
                    {
                        throw new Exception(fruits + "が見つかりません");
                    }

                    int fruitsNum = ZaikoList[fruits] - num;

                    if (0 <= fruitsNum)
                    {
                        Console.WriteLine("お買上げありがとうございます。");
                    }
                    else
                    {
                        throw new Exception("残り" + ZaikoList[fruits] + "個です。");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            BuyFruits(4, "リンゴ");
            BuyFruits(4, "ゴリラ");
            BuyFruits(5, "リンゴ");

            try
            {
                bool result = nameList.Contains("JaiAn");
                if (result)
                {
                    throw new Exception("Danger");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
