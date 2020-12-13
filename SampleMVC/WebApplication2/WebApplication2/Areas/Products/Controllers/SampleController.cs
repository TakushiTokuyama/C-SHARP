using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApplication2.Areas.Products;
using WebApplication2.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Sample
{
    [Area("Products")]
    public class SampleController : Controller
    {
        private readonly IPersonRepository _repository;
        private readonly ILogger<SampleController> _logger;

        public SampleController(IPersonRepository repository, ILogger<SampleController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        //// GET: /<controller>/
        public IActionResult Index()
        {
            SampleViewModel viewModel = new SampleViewModel();

            viewModel = _repository.FindPerson();

            return View("index", viewModel);
        }

        public IActionResult Create() {

            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("PersonId", "Name", "Mail", "Age")]Person person) {

            if (ModelState.IsValid)
            {
                _repository.Save(person);
            }
            return View(person);
        }

        [HttpGet]
        public IActionResult Sample2(Person person) {

            var person1 = HttpContext.Session.GetObject<Person>("person1");

            if (person1 != null)
            {
                return View(person1);
            }


            return View(person);
        }

        [HttpPost]
        public IActionResult Sample2Find([Bind("Name", "Age")]Person person) {

            person.Age = "1";

            HttpContext.Session.SetObject("person1", person);

            return Redirect("Sample2");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = _repository.FindDetailsPerson(id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = _repository.FindId(id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("PersonId,Name,Mail,Age")] Person person)
        {
            if (id != person.PersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.UpdatePerson(person);
                }
                catch (DbUpdateConcurrencyException)
                {
                        throw; 
                }
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }
    }


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
