using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TlaxRatio.Models.SimpleInvoice
{
    public partial class InvoiceLine
    {
        public void RecalculateTotal()
        {
            Total = Qty * UnitPrice;
        }
    }
}
