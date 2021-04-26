using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleInvoiceManagementSoftware.Models.SimpleInvoice
{
  [Table("Product", Schema = "dbo")]
  public partial class Product
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId
    {
      get;
      set;
    }

    public ICollection<InvoiceLine> InvoiceLines { get; set; }
    public string Name
    {
      get;
      set;
    }
    public string Description
    {
      get;
      set;
    }
    public double UnitPrice
    {
      get;
      set;
    }
  }
}
