using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;
using System.Collections.Generic;
using TlaxRatio.Models.RatioModels;
 

namespace TlaxRatio.Server.Pages
{
    public partial class EditInvoiceComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected SecurityService Security { get; set; }

        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        protected RatioDataService SimpleInvoice { get; set; }

        [Parameter]
        public dynamic InvoiceId { get; set; }
        protected RadzenGrid<InvoiceLine> grid0;

        Invoice _invoice;
        protected Invoice invoice
        {
            get
            {
                return _invoice;
            }
            set
            {
                if (!object.Equals(_invoice, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "invoice", NewValue = value, OldValue = _invoice };
                    _invoice = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Company> _getCompaniesForCompanyIdResult;
        protected IEnumerable<Company> getCompaniesForCompanyIdResult
        {
            get
            {
                return _getCompaniesForCompanyIdResult;
            }
            set
            {
                if (!object.Equals(_getCompaniesForCompanyIdResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getCompaniesForCompanyIdResult", NewValue = value, OldValue = _getCompaniesForCompanyIdResult };
                    _getCompaniesForCompanyIdResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Customer> _getCustomersForCustomerIdResult;
        protected IEnumerable<Customer> getCustomersForCustomerIdResult
        {
            get
            {
                return _getCustomersForCustomerIdResult;
            }
            set
            {
                if (!object.Equals(_getCustomersForCustomerIdResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getCustomersForCustomerIdResult", NewValue = value, OldValue = _getCustomersForCustomerIdResult };
                    _getCustomersForCustomerIdResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Tax> _getTaxesForTaxIdResult;
        protected IEnumerable<Tax> getTaxesForTaxIdResult
        {
            get
            {
                return _getTaxesForTaxIdResult;
            }
            set
            {
                if (!object.Equals(_getTaxesForTaxIdResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getTaxesForTaxIdResult", NewValue = value, OldValue = _getTaxesForTaxIdResult };
                    _getTaxesForTaxIdResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<InvoiceLine> _InvoiceLines;
        protected IEnumerable<InvoiceLine> InvoiceLines
        {
            get
            {
                return _InvoiceLines;
            }
            set
            {
                if (!object.Equals(_InvoiceLines, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "InvoiceLines", NewValue = value, OldValue = _InvoiceLines };
                    _InvoiceLines = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _CompanyAddress;
        protected string CompanyAddress
        {
            get
            {
                return _CompanyAddress;
            }
            set
            {
                if (!object.Equals(_CompanyAddress, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "CompanyAddress", NewValue = value, OldValue = _CompanyAddress };
                    _CompanyAddress = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _CompanyCity;
        protected string CompanyCity
        {
            get
            {
                return _CompanyCity;
            }
            set
            {
                if (!object.Equals(_CompanyCity, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "CompanyCity", NewValue = value, OldValue = _CompanyCity };
                    _CompanyCity = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _CustomerAddress;
        protected string CustomerAddress
        {
            get
            {
                return _CustomerAddress;
            }
            set
            {
                if (!object.Equals(_CustomerAddress, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "CustomerAddress", NewValue = value, OldValue = _CustomerAddress };
                    _CustomerAddress = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _CustomerCity;
        protected string CustomerCity
        {
            get
            {
                return _CustomerCity;
            }
            set
            {
                if (!object.Equals(_CustomerCity, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "CustomerCity", NewValue = value, OldValue = _CustomerCity };
                    _CustomerCity = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Security.InitializeAsync(AuthenticationStateProvider);
            if (!Security.IsAuthenticated())
            {
                UriHelper.NavigateTo("Login", true);
            }
            else
            {
                await Load();
            }
        }
        protected async System.Threading.Tasks.Task Load()
        {
            InvoiceId = int.Parse(InvoiceId);

            var simpleInvoiceGetInvoiceByInvoiceIdResult = await SimpleInvoice.GetInvoiceByInvoiceId(InvoiceId);
            invoice = simpleInvoiceGetInvoiceByInvoiceIdResult;

            var simpleInvoiceGetCompaniesResult = await SimpleInvoice.GetCompanies();
            getCompaniesForCompanyIdResult = simpleInvoiceGetCompaniesResult;

            var simpleInvoiceGetCustomersResult = await SimpleInvoice.GetCustomers();
            getCustomersForCustomerIdResult = simpleInvoiceGetCustomersResult;

            var simpleInvoiceGetTaxesResult = await SimpleInvoice.GetTaxes();
            getTaxesForTaxIdResult = simpleInvoiceGetTaxesResult;

            var simpleInvoiceGetInvoiceLinesResult = await SimpleInvoice.GetInvoiceLines(new Query() { Filter = $@"i => i.InvoiceId == {invoice.InvoiceId}" });
            InvoiceLines = simpleInvoiceGetInvoiceLinesResult;

            await SelectedTax(invoice.TaxId.Value,InvoiceLines);

            CompanyAddress = "";

            CompanyCity = "";

            CustomerAddress = "";

            CustomerCity = "";

            await SelectedCompany(invoice.CompanyId.Value);

            await SelectedCustomer(invoice.CustomerId.Value);
        }

        protected async System.Threading.Tasks.Task TaxIdChange(dynamic args)
        {
            await SelectedTax(args,InvoiceLines);
        }

        protected async System.Threading.Tasks.Task CompanyIdChange(dynamic args)
        {
            await SelectedCompany(args);
        }

        protected async System.Threading.Tasks.Task CustomerIdChange(dynamic args)
        {
            await SelectedCustomer(args);
        }

        protected async System.Threading.Tasks.Task BtnAddClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddInvoiceLine>("Add Invoice Line", new Dictionary<string, object>() { {"InvoiceId", InvoiceId} }, new DialogOptions(){ Width = $"{700}px" });
            await grid0.Reload();

            await RecalculateSummary(invoice,InvoiceLines);
        }

        protected async System.Threading.Tasks.Task BtnPrintInvoiceClick(MouseEventArgs args)
        {
            await ExportPDF(invoice);
        }

        protected void  BtnPreviewClick(MouseEventArgs args)
        {
            UriHelper.NavigateTo($"previewPdf/{invoice.InvoiceId}");
        }

        protected async System.Threading.Tasks.Task BtnDeleteClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var simpleInvoiceDeleteInvoiceLineResult = await SimpleInvoice.DeleteInvoiceLine(data.InvoiceLineId);
                    if (simpleInvoiceDeleteInvoiceLineResult != null)
                    {
                        await RecalculateMasterAfterChildDelete(invoice,InvoiceLines);
                    }

                    if (simpleInvoiceDeleteInvoiceLineResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception simpleInvoiceDeleteInvoiceLineException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete InvoiceLine" });
            }
        }

        protected async System.Threading.Tasks.Task DiscountChange(double args)
        {
            await ChangeDiscount(args,InvoiceLines);
        }

        protected async System.Threading.Tasks.Task Form0Submit(Invoice args)
        {
            try
            {
                var simpleInvoiceUpdateInvoiceResult = await SimpleInvoice.UpdateInvoice(InvoiceId, invoice);
                UriHelper.NavigateTo("invoices");
            }
            catch (System.Exception simpleInvoiceUpdateInvoiceException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update Invoice" });
            }
        }

        protected async System.Threading.Tasks.Task BtnCancelClick(MouseEventArgs args)
        {
            UriHelper.NavigateTo("invoices");
        }
    }
}
