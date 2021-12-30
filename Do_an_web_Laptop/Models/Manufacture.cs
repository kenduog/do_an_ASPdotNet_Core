using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Do_an_web_Laptop.Models
{
    public class Manufacture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string National { get; set; }
        public bool Status { get; set; }
        public List<LaptopSerie> LaptopSeries { get; set; }
    }
}
