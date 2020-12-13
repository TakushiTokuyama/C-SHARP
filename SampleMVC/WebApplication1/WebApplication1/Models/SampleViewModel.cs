using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class SampleViewModel
    {
        public string list { get; set; }

        public List<SelectListItem> DropDownList { get; set; } = new List<SelectListItem>()
        {
            new SelectListItem { Text = "Zaiko1", Value = "1" },
            new SelectListItem { Text = "Zaiko2", Value = "2" },
            new SelectListItem { Text = "Zaiko3", Value = "3" }
        };

        public string Result { get; set; }
    }
}
