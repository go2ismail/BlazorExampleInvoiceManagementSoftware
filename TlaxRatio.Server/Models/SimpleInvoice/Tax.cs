using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TlaxRatio.Models.SimpleInvoice
{
  [Table("Tax", Schema = "dbo")]
  public partial class Tax
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TaxId
    {
      get;
      set;
    }

    public ICollection<Invoice> Invoices { get; set; }
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
    public double TaxTariffPercentage
    {
      get;
      set;
    }
  }
}
