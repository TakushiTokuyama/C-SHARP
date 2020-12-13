using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Areas.Products;
using WebApplication2.Models;

namespace WebApplication2
{
  public class PersonRepository : IPersonRepository
    {
        private readonly Context _context;
        public PersonRepository(Context context)
        {
            _context = context;
        }

        public SampleViewModel FindPerson() 
        {
            string A = "11";

            var personQuery = _context.Set<Person>();

            SampleViewModel viewModel = new SampleViewModel();

            viewModel.PersonList = personQuery.ToList();

            return viewModel;
        }

        public IEnumerable<Test> FindTest()
        {
            return _context.Set<Test>();
        }

        public void Save(Person person) {
            _context.Set<Person>().Add(person);
            _context.SaveChanges();
        }

        public SampleViewModel FindDetailsPerson(int?
            id)
        {
            var personQuery = _context.Set<Person>().FirstOrDefault(p => p.PersonId == id);

            SampleViewModel viewModel = new SampleViewModel();

            viewModel.Person = personQuery;

            return viewModel;
        }

        public SampleViewModel FindId(int? id)
        {
            var personQuery = _context.Set<Person>().Find(id);

            SampleViewModel viewModel = new SampleViewModel();

            viewModel.Person = personQuery;

            return viewModel;
        }

        public void UpdatePerson(Person person)
        {
            _context.Update(person);
            _context.SaveChanges();
        }
    }
}