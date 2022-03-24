using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Invoice
    {
        public int InvoiceId { get; set; }

        [Required]
        [StringLength(100)]
        public string InvoiceNumber { get; set; }

        [Required]
        public Company Company { get; set; }

        [NotMapped]
        public string CompanyName
        {
            get { return Company.Name; }
        }

        [NotMapped]
        public string CompanyAddress
        {
            get { return Company.Address; }
        }

        [NotMapped]
        public string CompanyCity
        {
            get { return Company.City; }
        }

        [Required]
        public Customer Customer { get; set; }

        [NotMapped]
        public string CustomerName
        {
            get { return Customer.Name; }
        }

        [NotMapped]
        public string CustomerAddress
        {
            get { return Customer.Address; }
        }

        [NotMapped]
        public string CustomerCity
        {
            get { return Customer.City; }
        }

        [Required]
        public DateTime InvoiceDate { get; set; }

        [Required]
        public DateTime InvoiceDueDate { get; set; }
        
        [Required]
        public Tax Tax { get; set; }

        public double Total { get; set; }
        public double Discount { get; set; }
        public double BeforeTax { get; set; }
        public double TaxAmount { get; set; }
        public double GrandTotal { get; set; }

        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
    }
}
