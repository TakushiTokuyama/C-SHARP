using System.Collections.Generic;

namespace WebApplication3.Models
{
    public class AutoMapperSampleViewModel
    {
        public IList<Staff> Staff { get; set; }
        public int? Seq_id { get; set; }
        public int? Joiny { get; set; }
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
    }
}
