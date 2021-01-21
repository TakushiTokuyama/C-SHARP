using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCollection
{
    public class CountService
    {
        public int getCountService()
        {
            var syakeBentou = new FoodEntity("しゃけ弁当",450,1);

            var yakinikuBentou = new FoodEntity("焼肉弁当", 500, 1);

            var noriBentou = new FoodEntity("のり弁当", 400, 1);

            var total = 0;

            total += syakeBentou.foodPrice * syakeBentou.foodNum;
            total += yakinikuBentou.foodPrice * yakinikuBentou.foodNum;
            total += noriBentou.foodPrice * noriBentou.foodNum;

            return total;
        }

        public string ParseLogLine(string input)
        {
            var sanitizedInput = TrimInput(input);
            return sanitizedInput;
        }

        private string TrimInput(string input)
        {
            return input.Trim();
        }
    }
}
