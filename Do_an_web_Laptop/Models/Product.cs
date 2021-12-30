using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Do_an_web_Laptop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Deccription { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public int LaptopSerieId { get; set; }
        public LaptopSerie LaptopSerie { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string GPU { get; set; }
        public string Monitor { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        public List<Cart> Carts { get; set; }
        public List<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
