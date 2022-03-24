using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using TlaxRatio.Models.SimpleInvoice;

namespace TlaxRatio.Server.Pages
{
    public partial class AddInvoiceLineComponent
    {

        public async Task<InvoiceLine> ProcessSubmit(InvoiceLine invoiceLine)
        {
            var invoiceLines = await SimpleInvoice
                .GetInvoiceLines(new Query() { Filter = $"x => x.InvoiceId = {invoiceLine.InvoiceId}"});

            var exists = invoiceLines
                .ToList()
                .Where(x => x.ProductId.Equals(invoiceLine.ProductId))
                .FirstOrDefault();

            if (exists != null)
            {
                exists.Qty = exists.Qty + invoiceLine.Qty;
                exists.RecalculateTotal();
                return await SimpleInvoice.UpdateInvoiceLine(exists.InvoiceLineId, exists);
            }
            else
            {
                return await SimpleInvoice.CreateInvoiceLine(invoiceline);
            }
        }

        public async Task InitObject(InvoiceLine invoiceLine)
        {
            invoiceLine.InvoiceId = InvoiceId;
            invoiceLine.Qty = 1;
            invoiceLine.ProductId = 1;
            await SelectedProduct(1, invoiceLine);
        }

        public async Task SelectedProduct(int productId, InvoiceLine invoiceLine)
        {
            var product = await SimpleInvoice.GetProductByProductId(productId);
            if (product != null)
            {
                invoiceline.UnitPrice = product.UnitPrice;
                invoiceline.RecalculateTotal();
            }
        }

        public async Task ChangeQty(double qty, InvoiceLine invoiceLine)
        {
            invoiceline.Qty = qty;
            invoiceLine.RecalculateTotal();
        }

        public async Task ChangePrice(double price, InvoiceLine invoiceLine)
        {
            invoiceline.UnitPrice = price;
            invoiceline.RecalculateTotal();
        }

      
    }
}
