using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCode
{
    public class RecommendedBooks
    {
        public string GetReturnFavoriteBook(string Caterogy, Dictionary<string, string> Books)
        {
            switch (Caterogy)
            {
                case "アニメ":
                    return Books.FirstOrDefault(book => book.Key == "アニメ").Value;

                case "歴史":
                    return Books.FirstOrDefault(book => book.Key == "歴史").Value;

                case "プログラミング":
                    return Books.FirstOrDefault(book => book.Key == "プログラミング").Value;

                default:
                    return null;
            }
        }
    }
}