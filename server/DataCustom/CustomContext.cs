using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;

namespace SimpleInvoiceManagementSoftware
{
    public class CustomContext : DbContext
    {
        public CustomContext(DbContextOptions<CustomContext> options)
         : base(options)
        {
            
        }

        public DbSet<Company> Company { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceLine> InvoiceLine { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Tax> Tax { get; set; }
    }
}
