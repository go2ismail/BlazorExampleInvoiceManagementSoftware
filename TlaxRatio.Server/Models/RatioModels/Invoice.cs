using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TlaxRatio.Models.RatioModels
{
    [Table("Invoice", Schema = "dbo")]
    public partial class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }
        public ICollection<InvoiceLine> InvoiceLines { get; set; }
        public string InvoiceNumber { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime InvoiceDueDate { get; set; }
        public int? TaxId { get; set; }
        public Tax Tax { get; set; }
        public double Total { get; set; }
        public double Discount { get; set; }
        public double BeforeTax { get; set; }
        public double TaxAmount { get; set; }
        public double GrandTotal { get; set; }
    }
}