using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TlaxRatio.Models.SimpleInvoice
{

    public partial class Invoice
    {
        public void RecalculateTotal()
        {
            if (InvoiceLines != null)
            {
                Total = InvoiceLines.Sum(x => x.Total);
                if (Total > 0)
                {
                    Discount = Discount <= Total ? Discount : Total;
                    BeforeTax = Total - Discount;
                    if (Tax != null)
                    {
                        TaxAmount = (Tax.TaxTariffPercentage / 100.0) * BeforeTax;
                    }
                    else
                    {
                        TaxAmount = 0;
                    }
                    GrandTotal = BeforeTax + TaxAmount;
                }
                else if (Total == 0)
                {
                    BeforeTax = 0;
                    Discount = 0;
                    TaxAmount = 0;
                    GrandTotal = 0;
                }
                
            }
        }
    }
}
