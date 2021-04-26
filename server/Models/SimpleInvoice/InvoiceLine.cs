using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleInvoiceManagementSoftware.Models.SimpleInvoice
{
  [Table("InvoiceLine", Schema = "dbo")]
  public partial class InvoiceLine
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int InvoiceLineId
    {
      get;
      set;
    }
    public int InvoiceId
    {
      get;
      set;
    }
    public Invoice Invoice { get; set; }
    public int? ProductId
    {
      get;
      set;
    }
    public Product Product { get; set; }
    public double Qty
    {
      get;
      set;
    }
    public double UnitPrice
    {
      get;
      set;
    }
    public double Total
    {
      get;
      set;
    }
  }
}
