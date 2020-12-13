using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Context;
using WebApplication3.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication3.Controllers
{
    public class SampleController : Controller
    {
        private readonly SampleContext _context;
        private readonly IMapper _mapper;

        public SampleController(SampleContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Sample Controller
        /// </summary>C:\repos\C#Sample\SampleMVC\WebApplication3\WebApplication3\Views\Shared\
        /// <returns>初期表示</returns>
        [HttpGet]
        public IActionResult Sample()
        {
            var zaiko = _context.Set<Zaiko>().ToList();

            SampleViewModel viewModel = new SampleViewModel();

            viewModel.ZaikoList = zaiko;

            return View(viewModel);
        }

        /// <summary>
        /// 更新処理　controller
        /// </summary>
        /// <param name="viewModel">更新model</param>
        /// <returns>更新</returns>
        [HttpPost]
        public IActionResult Update(SampleViewModel viewModel)
        {
            _context.Update(viewModel.Zaiko);
            _context.SaveChanges();
   
            return Redirect("Sample");
        }

        /// <summary>
        /// 全件更新 controller
        /// </summary>
        /// <returns>全件更新</returns>
        [HttpPost]
        public IActionResult AllUpdate()
        {
            IList<Zaiko> zaikoList = _context.Set<Zaiko>().ToList();

            foreach (var item in zaikoList)
            {
                var zaiko = int.Parse(item.ZaikoStock) - 1;

                item.ZaikoStock = zaiko.ToString();

                _context.Update(item);
                _context.SaveChanges();
            }

            return Redirect("Sample");
        }
        /// <summary>
        /// 在庫の名前と一致してたら更新 controller
        /// </summary>
        /// <param name="name"></param>
        /// <returns>一致更新</returns>
        [HttpPost]
        public IActionResult ZaikoNameUpdate(SampleViewModel viewModel)
        {
            var zaiko = _context.Set<Zaiko>().Where(z => z.ProductName == viewModel.Zaiko.ProductName);

            var zaikoStock = int.Parse(zaiko.First().ZaikoStock) - 1;

            zaiko.First().ZaikoStock = zaikoStock.ToString();

            _context.Update(zaiko.First());

            _context.SaveChanges();

            return Redirect("Sample"); 
        }

        [HttpGet]
        public IActionResult GridSample()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Kbn(SampleViewModel viewModel)
        {
            List<Zaiko> zaikoList = new List<Zaiko>();

            if (viewModel.editList == "1")
            {
                // 1更新
                zaikoList = _context.Set<Zaiko>().Take(1).ToList();
            }

            if (viewModel.editList == "2")
            {
                // 全件更新
                zaikoList = _context.Set<Zaiko>().ToList();
            }

            if (viewModel.zaikoNum != null)
            {
                // zaikoNumの数だけ更新
                zaikoList = _context.Set<Zaiko>().Take(int.Parse(viewModel.zaikoNum)).ToList();
            }

            foreach (var item in zaikoList)
            {
                _context.Update(item);
                _context.SaveChanges();
            }

            return Redirect("Sample");
        }

        public IActionResult UniqueKeyUpdate() 
        {
            var Staff = _context.Set<Staff>();

            List<Staff> result = new List<Staff>();

            // 結果詰替 NULL値表示
            foreach (var item in Staff)
            {
                Staff staffRow = new Staff()
                {
                    Joiny = item.Joiny == null ? null : item.Joiny,
                    Id = item.Id == null ? null : item.Id,
                    Name = item.Name == null ? "Null" : item.Name
                };
                result.Add(staffRow);
            }

            UniqueViewModel uniqueViewModel = new UniqueViewModel();

            uniqueViewModel.staffList = result;

            return View("UniqueKeyUpdate",uniqueViewModel);
        }

        public IActionResult UniqueKeyUpdatePost(Staff staff)
        {

            if (staff.Seq_id == 0)
            {
                return Redirect("UniqueKeyUpdate");
            }
            
            _context.Update(staff);
            _context.SaveChanges();
            
            return Redirect("UniqueKeyUpdate");
        }

        public IActionResult AutoMapperSample() 
        {
            var staffQuery = _context.Set<Staff>().AsNoTracking().ToList();

            var staffDto = _mapper.Map<IList<StaffDto>>(staffQuery);

            var staff = _mapper.Map<IList<Staff>>(staffDto);

            AutoMapperSampleViewModel viewModel = new AutoMapperSampleViewModel();

            viewModel.Staff = staff;

            viewModel.Seq_id = null;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AutoMapperSamplePost(Staff staffParameter)
        {
           var entity = _mapper.Map<StaffDto>(new Staff());

           entity = _mapper.Map<StaffDto>(staffParameter);

           entity.Place = null;

           var staffDto = _mapper.Map<StaffDto>(staffParameter);

           var staff = _mapper.Map<Staff>(entity);

           _context.Update(staff);
           _context.SaveChanges();
            
           return Redirect("AutoMapperSample");
        }

    }
}
