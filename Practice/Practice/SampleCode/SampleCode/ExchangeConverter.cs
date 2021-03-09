using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCode
{
    /// <summary>
    /// 為替
    /// </summary>
    public class ExchangeConverter
    {
        private ConverterBase From { get; set; }

        private ConverterBase To { get; set; }

        public ExchangeConverter(ConverterBase from, ConverterBase to) 
        {
            From = from;
            To = to;
        }

        /// <summary>
        /// コンバーター
        /// </summary>
        /// <returns>結果</returns>
        public double Convert(double value) 
        {
            var yen = From.ToYen(value);
            return To.FromYen(yen);
        }
    }
}
