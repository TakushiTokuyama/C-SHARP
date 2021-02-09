using System;
using System.Collections.Generic;
using System.Text;

namespace C_SHARP_7._0
{
    class NumberSort
    {
        public void sample()
        {
            // タプル
            (string, int) nameAndAge = ("A", 11);

            Console.WriteLine($"{nameAndAge.Item1}{nameAndAge.Item2}");

            // フィールド名
            var countryAndcity = (CountryName: "日本", CityName: "Osaka");

            Console.WriteLine($"{countryAndcity.CountryName}の{countryAndcity.CityName}");
        }

        // 1-10とそれ以外に分ける
        public (List<int> fromOneToTen, List<int>  other) Ranking(List<int> numbers)
        {
            var fromOneToTen = new List<int>();
            var other = new List<int>();

            numbers.ForEach(num =>
            {
                if (num < 11)
                {
                    fromOneToTen.Add(num);
                }
                else
                {
                    other.Add(num);
                }
            });

            return (fromOneToTen, other);
        }
    }
}
