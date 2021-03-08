using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCode
{
    public abstract class ConverterBase
    {
        /// <summary>
        /// 通貨の比率
        /// </summary>
        public abstract double Ratio { get;}

        /// <summary>
        /// 通貨の名前
        /// </summary>
        public abstract string CurrencyName {get;}

        /// <summary>
        /// 円からの変換
        /// </summary>
        /// <param name="yen">日本円</param>
        /// <returns>円からの変換</returns>
        public double FromYen(double yen) 
        {
            return yen / Ratio;
        }

        /// <summary>
        /// 円への変換
        /// </summary>
        /// <param name="yen">日本円</param>
        /// <returns>円への変換</returns>
        public double ToYen(double yen) 
        {
            return yen * Ratio; 
        }   
    }


}
