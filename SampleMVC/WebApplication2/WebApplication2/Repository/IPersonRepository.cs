using System.Collections.Generic;
using WebApplication2.Areas.Products;
using WebApplication2.Models;

namespace WebApplication2
{
    public interface IPersonRepository
    {
        public SampleViewModel FindPerson();

        public IEnumerable<Test> FindTest();

        public void Save(Person person);

        public SampleViewModel FindId(int? id);

        public void UpdatePerson(Person person);

        public SampleViewModel FindDetailsPerson(int? id);
    }
}