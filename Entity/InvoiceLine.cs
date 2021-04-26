using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class InvoiceLine
    {
        public int InvoiceLineId { get; set; }

        public int InvoiceId { get; set; }

        public virtual Invoice Invoice { get; set; }

        [NotMapped]
        public string CompanyName
        {
            get { return Invoice.Company.Name; }
        }

        [NotMapped]
        public string CompanyAddress
        {
            get { return Invoice.Company.Address; }
        }

        [NotMapped]
        public string CompanyCity
        {
            get { return Invoice.Company.City; }
        }

        [NotMapped]
        public string CustomerName
        {
            get { return Invoice.Customer.Name; }
        }

        [NotMapped]
        public string CustomerAddress
        {
            get { return Invoice.Customer.Address; }
        }

        [NotMapped]
        public string CustomerCity
        {
            get { return Invoice.Customer.City; }
        }

        [NotMapped]
        public string InvoiceNumber
        {
            get { return Invoice.InvoiceNumber; }
        }

        [NotMapped]
        public string InvoiceDate
        {
            get { return Invoice.InvoiceDate.ToString("yyy-MM-dd"); }
        }

        [NotMapped]
        public string InvoiceDueDate
        {
            get { return Invoice.InvoiceDate.ToString("yyy-MM-dd"); }
        }

        [NotMapped]
        public string SubTotal
        {
            get { return Invoice.Total.ToString("##,##.00"); }
        }

        [NotMapped]
        public string Discount
        {
            get { return Invoice.Discount.ToString("##,##.00"); }
        }

        [NotMapped]
        public string BeforeTax
        {
            get { return Invoice.BeforeTax.ToString("##,##.00"); }
        }

        [NotMapped]
        public string Tax
        {
            get { return Invoice.TaxAmount.ToString("##,##.00"); }
        }

        [NotMapped]
        public string GrandTotal
        {
            get { return Invoice.GrandTotal.ToString("##,##.00"); }
        }

        [Required]
        public Product Product { get; set; }

        [NotMapped]
        public string ProductName
        {
            get { return Product.Name; }
        }

        [Required]
        public double Qty { get; set; }

        [Required]
        public double UnitPrice { get; set; }

        [Required]
        public double Total { get; set; }
    }
}
