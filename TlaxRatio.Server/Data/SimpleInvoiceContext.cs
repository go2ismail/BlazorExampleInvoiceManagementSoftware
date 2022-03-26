using Microsoft.EntityFrameworkCore;

using TlaxRatio.Models.RatioModels;

namespace TlaxRatio.Data
{
    public partial class SimpleInvoiceContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public SimpleInvoiceContext(DbContextOptions<SimpleInvoiceContext> options) : base(options)
        {
        }

        public SimpleInvoiceContext()
        {
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Invoice>()
                  .HasOne(i => i.Company)
                  .WithMany(i => i.Invoices)
                  .HasForeignKey(i => i.CompanyId)
                  .HasPrincipalKey(i => i.CompanyId);
            builder.Entity<Invoice>()
                  .HasOne(i => i.Customer)
                  .WithMany(i => i.Invoices)
                  .HasForeignKey(i => i.CustomerId)
                  .HasPrincipalKey(i => i.CustomerId);
            builder.Entity<Invoice>()
                  .HasOne(i => i.Tax)
                  .WithMany(i => i.Invoices)
                  .HasForeignKey(i => i.TaxId)
                  .HasPrincipalKey(i => i.TaxId);
            builder.Entity<InvoiceLine>()
                  .HasOne(i => i.Invoice)
                  .WithMany(i => i.InvoiceLines)
                  .HasForeignKey(i => i.InvoiceId)
                  .HasPrincipalKey(i => i.InvoiceId);
            builder.Entity<InvoiceLine>()
                  .HasOne(i => i.Product)
                  .WithMany(i => i.InvoiceLines)
                  .HasForeignKey(i => i.ProductId)
                  .HasPrincipalKey(i => i.ProductId);


            builder.Entity<Invoice>()
                  .Property(p => p.InvoiceDate)
                  .HasColumnType("datetime2");

            builder.Entity<Invoice>()
                  .Property(p => p.InvoiceDueDate)
                  .HasColumnType("datetime2");

            builder.Entity<Company>()
                  .Property(p => p.CompanyId)
                  .HasPrecision(10, 0);

            builder.Entity<Customer>()
                  .Property(p => p.CustomerId)
                  .HasPrecision(10, 0);

            builder.Entity<Invoice>()
                  .Property(p => p.InvoiceId)
                  .HasPrecision(10, 0);

            builder.Entity<Invoice>()
                  .Property(p => p.CompanyId)
                  .HasPrecision(10, 0);

            builder.Entity<Invoice>()
                  .Property(p => p.CustomerId)
                  .HasPrecision(10, 0);

            builder.Entity<Invoice>()
                  .Property(p => p.TaxId)
                  .HasPrecision(10, 0);

            builder.Entity<Invoice>()
                  .Property(p => p.Total)
                  .HasPrecision(53, 0);

            builder.Entity<Invoice>()
                  .Property(p => p.Discount)
                  .HasPrecision(53, 0);

            builder.Entity<Invoice>()
                  .Property(p => p.BeforeTax)
                  .HasPrecision(53, 0);

            builder.Entity<Invoice>()
                  .Property(p => p.TaxAmount)
                  .HasPrecision(53, 0);

            builder.Entity<Invoice>()
                  .Property(p => p.GrandTotal)
                  .HasPrecision(53, 0);

            builder.Entity<InvoiceLine>()
                  .Property(p => p.InvoiceLineId)
                  .HasPrecision(10, 0);

            builder.Entity<InvoiceLine>()
                  .Property(p => p.InvoiceId)
                  .HasPrecision(10, 0);

            builder.Entity<InvoiceLine>()
                  .Property(p => p.ProductId)
                  .HasPrecision(10, 0);

            builder.Entity<InvoiceLine>()
                  .Property(p => p.Qty)
                  .HasPrecision(53, 0);

            builder.Entity<InvoiceLine>()
                  .Property(p => p.UnitPrice)
                  .HasPrecision(53, 0);

            builder.Entity<InvoiceLine>()
                  .Property(p => p.Total)
                  .HasPrecision(53, 0);

            builder.Entity<Product>()
                  .Property(p => p.ProductId)
                  .HasPrecision(10, 0);

            builder.Entity<Product>()
                  .Property(p => p.UnitPrice)
                  .HasPrecision(53, 0);

            builder.Entity<Tax>()
                  .Property(p => p.TaxId)
                  .HasPrecision(10, 0);

            builder.Entity<Tax>()
                  .Property(p => p.TaxTariffPercentage)
                  .HasPrecision(53, 0);
            this.OnModelBuilding(builder);
        }


        public DbSet<Company> Companies { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<InvoiceLine> InvoiceLines { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Tax> Taxes { get; set; }
    }
}
