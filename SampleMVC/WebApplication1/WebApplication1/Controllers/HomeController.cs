using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Sample Controller
        /// </summary>
        /// <param name="viewModel">SampleViewModel</param>
        /// <returns>表示</returns>
        [HttpGet]
        public IActionResult Sample(SampleViewModel viewModel)
        {
            var result = HttpContext.Session.GetObject<SampleViewModel>("viewModel");

            if (result != null)
            {
                result.DropDownList = viewModel.DropDownList;

                return View(result);
            }
            else
            {
                return View(new SampleViewModel());
            }
        }

        /// <summary>
        /// SampleController
        /// </summary>
        /// <param name="viewModel">SampleViewModel</param>
        /// <returns>結果表示</returns>
        [HttpPost]
        public IActionResult SampleFind(SampleViewModel viewModel)
        {
            viewModel.Result = "成功";

            HttpContext.Session.SetObject("viewModel", viewModel);

            return Redirect("sample");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
    /// <summary>
    /// Session Object拡張メソッド
    /// </summary>
    public static class SessionExtentions
    {
        public static void SetObject<TObject>(this ISession session, string key, TObject obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            session.SetString(key, json);
        }

        public static TObject GetObject<TObject>(this ISession session, string key)
        {
            var json = session.GetString(key);
            return string.IsNullOrEmpty(json) ? default(TObject) : JsonConvert.DeserializeObject<TObject>(json);
        }
    }
}
