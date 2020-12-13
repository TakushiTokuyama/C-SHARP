using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using WebApplication3.Models.Sample01;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication3.Controllers
{
    public class Sample01Controller : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var viewModel = new Sample01ViewModel();

            if (HttpContext.Session.GetString("num") != null)
            {
                viewModel.num = HttpContext.Session.GetString("num");
            }

            return View(viewModel);
        }

        public IActionResult Find(Sample01ViewModel viewModel) {

            viewModel.num = "2";

            HttpContext.Session.SetString("num", viewModel.num);
            
            return Redirect("index");
        }

        public IActionResult ValidationSample() 
        {
            var viewModel = new Sample01ViewModel();

            if (HttpContext.Session.GetString("Name") != null)
            {
                viewModel.Name = HttpContext.Session.GetString("Name");
                viewModel.num = HttpContext.Session.GetString("num");
            }

            return View(viewModel);
        }

        public IActionResult ValidationSamplePost(Sample01ViewModel viewModel) 
        {
            if (!ModelState.IsValid) 
            {
                return View("ValidationSample");
            }

            viewModel.num = "1";

            HttpContext.Session.SetString("Name", viewModel.Name);
            HttpContext.Session.SetString("num", viewModel.num);

            return Redirect("ValidationSample");
        }

        /// <summary>
        /// 非活性/活性 サンプル
        /// </summary>
        /// <returns>index</returns>
        public IActionResult SampleDisabled() 
        {
            return View("SampleDisabled");
        }

        /// <summary>
        /// 非活性/活性 サンプル
        /// </summary>
        /// <param name="viewModel">viewModel</param>
        /// <returns>結果</returns>
        public IActionResult SampleDisabledPost(SampleDisabledViewModel viewModel)
        {

            viewModel.DaiResult = viewModel.Dai;
            viewModel.ChuResult = viewModel.Chu;
            viewModel.ShoResult = viewModel.Sho;
            viewModel.SetResult = viewModel.Dai + viewModel.Chu + viewModel.Sho;

            return View("SampleDisabled", viewModel);
        }
    }
}
