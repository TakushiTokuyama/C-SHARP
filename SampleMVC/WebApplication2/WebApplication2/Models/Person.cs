using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Person
    {

        public int PersonId { get; set; }
        [Display(Name="名前")]
        public string Name { get; set; }
        public string Mail { get; set; }
        [DataType(DataType.Text)]
        public string Age { get; set; }
    }
}
