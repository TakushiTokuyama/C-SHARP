using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCollection
{
    public class FoodEntity
    {
        /// <summary>
        /// 名前
        /// </summary>
        public string foodName { get; set; }

        /// <summary>
        /// 価格
        /// </summary>
        public int foodPrice { get; set; }

        /// <summary>
        /// 個数
        /// </summary>
        public int foodNum { get; set; }

        /// <summary>
        /// コンストラクタ―
        /// </summary>
        public FoodEntity(string foodName, int foodPrice, int foodNum)
        {
            this.foodName = foodName;
            this.foodPrice = foodPrice;
            this.foodNum = foodNum;
        }
    }
}
