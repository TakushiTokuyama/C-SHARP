using System;
using System.Collections.Generic;
using System.Linq;

namespace TicketVendingMachine
{
    public class VendingService
    {
        private bool existFlg = false;

        private bool enoughFlg = false;

        private int inputAmount;

        public void Execute()
        {
            // 商品の生成
            List<Food> foodList = new List<Food>();

            CreateFood(foodList);

            var priceList = new List<int>();

            // 商品代金リスト
            for (int i = 0; i < foodList.Count(); i++)
            {
                priceList.Add(foodList[i].FoodPrice);
            }

            // ループ開始
            while (true)
            {
                // お金を投入
                Console.WriteLine("お金を投入してください");
                Console.WriteLine("投入金額：" + inputAmount);

                inputAmount += int.Parse(Console.ReadLine());

                // 金額の確認
                if (priceList.Min() > inputAmount)
                {
                    Console.WriteLine("商品購入の金額が足りません。");
                    continue;
                }

                // 商品選択ループ
                while (true)
                {
                    // 商品の選択
                    Console.WriteLine("商品を選んでください");

                    Console.Write("商品名：");

                    for (int i = 0; i < foodList.Count(); i++)
                    {
                        Console.Write(foodList[i].FoodName + " ");
                    }

                    Console.Write(Environment.NewLine);

                    var inputFood = Console.ReadLine();

                    // 購入できる商品の確認
                    for (int i = 0; i < foodList.Count(); i++)
                    {
                        if (foodList[i].FoodName == inputFood && foodList[i].FoodStock > 0)
                        {
                            existFlg = true;
                            break;
                        }
                    }

                    if (!existFlg)
                    {
                        Console.WriteLine("商品名または在庫がありません。");
                        existFlg = false;
                        continue;
                    }

                    // 購入処理
                    for (int i = 0; i < foodList.Count(); i++)
                    {
                        if (foodList[i].FoodName.Contains(inputFood))
                        {
                            if (foodList[i].FoodPrice > inputAmount)
                            {
                                enoughFlg = true;
                                break;
                            }
                            inputAmount -= foodList[i].FoodPrice;
                        }
                    }

                    if (enoughFlg)
                    {
                        Console.WriteLine("お金が足りません。");
                        enoughFlg = false;
                        break;
                    }

                    // 商品購入
                    Console.WriteLine("商品を購入しました。");

                    // 再購入
                    Console.WriteLine("再購入しますか？");
                    Console.WriteLine("0:再購入 それ以外:処理終了");
                    var inputRepurchase = Console.ReadLine();

                    if (inputRepurchase == "0")
                    {
                        break;
                    }
                    else
                    {
                        // お釣りの返却
                        Console.WriteLine(inputAmount + "円、返却します。");
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 商品の生成
        /// </summary>
        /// <param name="foodList"></param>
        private void CreateFood(List<Food> foodList)
        {
            var onigiri = new Food("おにぎり", 100, 5);

            var teisyokuA = new Food("A定食", 500, 3);

            var teisyokuHi = new Food("日替わり定食定食", 400, 2);

            var soba = new Food("そば", 280, 4);

            foodList.Add(onigiri);
            foodList.Add(teisyokuA);
            foodList.Add(teisyokuHi);
            foodList.Add(soba);
        }
    }
}
