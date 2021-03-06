using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

using SimpleInvoiceManagementSoftware.Models.SimpleInvoice;

namespace SimpleInvoiceManagementSoftware.Data
{
  public partial class SimpleInvoiceContext : Microsoft.EntityFrameworkCore.DbContext
  {
    public SimpleInvoiceContext(DbContextOptions<SimpleInvoiceContext> options):base(options)
    {
    }

    public SimpleInvoiceContext()
    {
    }

    partial void OnModelBuilding(ModelBuilder builder);

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Invoice>()
              .HasOne(i => i.Company)
              .WithMany(i => i.Invoices)
              .HasForeignKey(i => i.CompanyId)
              .HasPrincipalKey(i => i.CompanyId);
        builder.Entity<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Invoice>()
              .HasOne(i => i.Customer)
              .WithMany(i => i.Invoices)
              .HasForeignKey(i => i.CustomerId)
              .HasPrincipalKey(i => i.CustomerId);
        builder.Entity<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Invoice>()
              .HasOne(i => i.Tax)
              .WithMany(i => i.Invoices)
              .HasForeignKey(i => i.TaxId)
              .HasPrincipalKey(i => i.TaxId);
        builder.Entity<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.InvoiceLine>()
              .HasOne(i => i.Invoice)
              .WithMany(i => i.InvoiceLines)
              .HasForeignKey(i => i.InvoiceId)
              .HasPrincipalKey(i => i.InvoiceId);
        builder.Entity<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.InvoiceLine>()
              .HasOne(i => i.Product)
              .WithMany(i => i.InvoiceLines)
              .HasForeignKey(i => i.ProductId)
              .HasPrincipalKey(i => i.ProductId);


        builder.Entity<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Invoice>()
              .Property(p => p.InvoiceDate)
              .HasColumnType("datetime2");

        builder.Entity<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Invoice>()
              .Property(p => p.InvoiceDueDate)
              .HasColumnType("datetime2");

        builder.Entity<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Company>()
              .Property(p => p.CompanyId)
              .HasPrecision(10, 0);

        builder.Entity<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Customer>()
              .Property(p => p.CustomerId)
              .HasPrecision(10, 0);

        builder.Entity<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Invoice>()
              .Property(p => p.InvoiceId)
              .HasPrecision(10, 0);

        builder.Entity<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Invoice>()
              .Property(p => p.CompanyId)
              .HasPrecision(10, 0);

        builder.Entity<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Invoice>()
              .Property(p => p.CustomerId)
              .HasPrecision(10, 0);

        builder.Entity<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Invoice>()
              .Property(p => p.TaxId)
              .HasPrecision(10, 0);

        builder.Entity<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Invoice>()
              .Property(p => p.Total)
              .HasPrecision(53, 0);

        builder.Entity<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Invoice>()
              .Property(p => p.Discount)
              .HasPrecision(53, 0);

        builder.Entity<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Invoice>()
              .Property(p => p.BeforeTax)
              .HasPrecision(53, 0);

        builder.Entity<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Invoice>()
              .Property(p => p.TaxAmount)
              .HasPrecision(53, 0);

        builder.Entity<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Invoice>()
              .Property(p => p.GrandTotal)
              .HasPrecision(53, 0);

        builder.Entity<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.InvoiceLine>()
              .Property(p => p.InvoiceLineId)
              .HasPrecision(10, 0);

        builder.Entity<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.InvoiceLine>()
              .Property(p => p.InvoiceId)
              .HasPrecision(10, 0);

        builder.Entity<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.InvoiceLine>()
              .Property(p => p.ProductId)
              .HasPrecision(10, 0);

        builder.Entity<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.InvoiceLine>()
              .Property(p => p.Qty)
              .HasPrecision(53, 0);

        builder.Entity<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.InvoiceLine>()
              .Property(p => p.UnitPrice)
              .HasPrecision(53, 0);

        builder.Entity<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.InvoiceLine>()
              .Property(p => p.Total)
              .HasPrecision(53, 0);

        builder.Entity<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Product>()
              .Property(p => p.ProductId)
              .HasPrecision(10, 0);

        builder.Entity<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Product>()
              .Property(p => p.UnitPrice)
              .HasPrecision(53, 0);

        builder.Entity<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Tax>()
              .Property(p => p.TaxId)
              .HasPrecision(10, 0);

        builder.Entity<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Tax>()
              .Property(p => p.TaxTariffPercentage)
              .HasPrecision(53, 0);
        this.OnModelBuilding(builder);
    }


    public DbSet<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Company> Companies
    {
      get;
      set;
    }

    public DbSet<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Customer> Customers
    {
      get;
      set;
    }

    public DbSet<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Invoice> Invoices
    {
      get;
      set;
    }

    public DbSet<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.InvoiceLine> InvoiceLines
    {
      get;
      set;
    }

    public DbSet<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Product> Products
    {
      get;
      set;
    }

    public DbSet<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Tax> Taxes
    {
      get;
      set;
    }
  }
}
