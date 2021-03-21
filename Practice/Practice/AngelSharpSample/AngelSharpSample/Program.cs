using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;

namespace AngelSharpSample
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            // タイトルを取得したいサイトのURL
            var urlstring = "xxxxxxxx";

            // 指定したサイトのHTMLをストリームで取得する
            var doc = default(IHtmlDocument);
            using (var client = new HttpClient())
            using (var stream = await client.GetStreamAsync(new Uri(urlstring)))
            {
                // AngleSharp.Html.Parser.HtmlParserオブジェクトにHTMLをパースさせる
                var parser = new HtmlParser();
                doc = await parser.ParseDocumentAsync(stream);
            }

            // HTMLからtitleタグの値(サイトのタイトルとして表示される部分)を取得する
            
            var items = doc.GetElementsByTagName("tr")
                .Select(o => 
            {
                var title = o.QuerySelector("td");
                return new { Title = title };
            
            });

        }
    }
}
