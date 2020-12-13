using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class SampleViewModel
    {
        public IList<Zaiko> ZaikoList { get; set; }

        public Zaiko Zaiko { get; set; }

        public string editList { get; set; }

        public string zaikoNum { get; set; }

        public List<SelectListItem> EditDropDownList { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Text = " ", Value = " "},
            new SelectListItem { Text = "一件更新", Value = "1"},
            new SelectListItem { Text = "全件更新", Value = "2"}
        };
    }
}
