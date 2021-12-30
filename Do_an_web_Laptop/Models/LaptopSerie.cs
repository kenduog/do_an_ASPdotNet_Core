using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Do_an_web_Laptop.Models
{
    public class LaptopSerie
    {
        public int Id { get; set; }
        public int ManufactureId { get; set; }
        public Manufacture Manufacture { get; set; }
        public string Name { get; set; }
        public DateTime ProductionTime { get; set; }
        public bool Status { get; set; }
    }
}
