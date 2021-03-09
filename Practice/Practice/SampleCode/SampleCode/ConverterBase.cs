namespace SampleCode
{
    public abstract class ConverterBase
    {
        /// <summary>
        /// 通貨の比率
        /// </summary>
        protected abstract double Ratio { get; }

        /// <summary>
        /// 通貨の名前
        /// </summary>
        public abstract string CurrencyName { get; }

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

    /// <summary>
    /// 円
    /// </summary>
    public class YenConverter : ConverterBase
    {
        protected override double Ratio { get { return 1; } }

        public override string CurrencyName { get { return "円"; } }
    }

    /// <summary>
    /// ドル
    /// </summary>
    public class DollerConverter : ConverterBase
    {
        protected override double Ratio { get { return 0.009182; } }

        public override string CurrencyName { get { return "ドル"; } }
    }

    /// <summary>
    /// ユーロ
    /// </summary>
    public class EuroConverter : ConverterBase
    {
        protected override double Ratio { get { return 0.007700; } }

        public override string CurrencyName { get { return "ユーロ"; } }
    }
}
