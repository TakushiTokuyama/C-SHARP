using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebApplication2.Models;

namespace WebApplication2.Areas.Products
{
    public class SampleViewModel
    {
        public int PersonId { get; set; }
        [Display(Name = "名前")]
        public string Name { get; set; }
        [Display(Name = "メール")]
        public string Mail { get; set; }
        [Display(Name = "年齢")]
        public string Age { get; set; }
        public IList<Person> PersonList { get; set; }

        public Person Person { get; set; }
    }
}
