using System;
using System.Collections.Generic;
using System.Text;

namespace TicketVendingMachine
{
    /// <summary>
    /// 食べ物クラス
    /// </summary>
    public class Food
    {
        /// <summary>
        /// 商品
        /// </summary>
        public String FoodName { get; set; }

        /// <summary>
        /// 値段
        /// </summary>
        public int FoodPrice { get; set; }

        /// <summary>
        /// 在庫
        /// </summary>
        public int FoodStock { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Food(String FoodName, int FoodPrice, int FoodStock) {
            this.FoodName = FoodName;
            this.FoodPrice = FoodPrice;
            this.FoodStock = FoodStock;
        }
    }
}
