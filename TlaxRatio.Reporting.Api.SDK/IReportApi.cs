using Refit;
using System.Reflection;

namespace TlaxRatio.Reporting.Api.SDK
{
    public partial interface  IReportApi
    {
        [Post("/Report/GetReportByteArray/")]
        Task<byte[]> ExportInvoiceToPdf( int invoiceId);
    }
}