using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Do_an_web_Laptop.Models;

namespace Do_an_web_Laptop.Data
{
    public class SaigonStoreContext :DbContext
    {
        public SaigonStoreContext(DbContextOptions<SaigonStoreContext> options): base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public DbSet<LaptopSerie> LaptopSeries { get; set; }
        public DbSet<Manufacture> Manufactures { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
