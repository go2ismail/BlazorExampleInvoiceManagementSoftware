using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using TlaxRatio.Models.RatioModels;

namespace TlaxRatio.Server.Pages
{
    public partial class PreviewPdfComponent
    {
     
        protected async System.Threading.Tasks.Task PreviewPdf(int invoiceId)
        {
            await SimpleInvoice.PrintInvoiceToPDF(invoiceId);
        }
    }
}
