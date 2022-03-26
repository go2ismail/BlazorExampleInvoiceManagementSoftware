using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using TlaxRatio.Models.RatioModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using TlaxRatio.Models;

namespace TlaxRatio.Server.Pages
{
    public partial class InvoicesComponent : ComponentBase
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
        protected RadzenGrid<Invoice> grid0;

        string _search;
        protected string search
        {
            get
            {
                return _search;
            }
            set
            {
                if (!object.Equals(_search, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "search", NewValue = value, OldValue = _search };
                    _search = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Invoice> _getInvoicesResult;
        protected IEnumerable<Invoice> getInvoicesResult
        {
            get
            {
                return _getInvoicesResult;
            }
            set
            {
                if (!object.Equals(_getInvoicesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getInvoicesResult", NewValue = value, OldValue = _getInvoicesResult };
                    _getInvoicesResult = value;
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
            if (string.IsNullOrEmpty(search)) {
                search = "";
            }

            var simpleInvoiceGetInvoicesResult = await SimpleInvoice.GetInvoices(new Query() { Filter = $@"i => i.InvoiceNumber.Contains(@0)", FilterParameters = new object[] { search }, Expand = "Company,Customer,Tax" });
            getInvoicesResult = simpleInvoiceGetInvoicesResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddInvoice>("Add Invoice", null, new DialogOptions(){ Width = $"{800}px" });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await SimpleInvoice.ExportInvoicesToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "Company,Customer,Tax", Select = "InvoiceId,InvoiceNumber,Company.Name,Customer.Name,InvoiceDate,InvoiceDueDate,Tax.Name,Total,Discount,BeforeTax,TaxAmount,GrandTotal" }, $"Invoices");

            }

            if (args == null || args.Value == "xlsx")
            {
                await SimpleInvoice.ExportInvoicesToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "Company,Customer,Tax", Select = "InvoiceId,InvoiceNumber,Company.Name,Customer.Name,InvoiceDate,InvoiceDueDate,Tax.Name,Total,Discount,BeforeTax,TaxAmount,GrandTotal" }, $"Invoices");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(Invoice args)
        {
            UriHelper.NavigateTo($"edit-invoice/{args.InvoiceId}");
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var simpleInvoiceDeleteInvoiceResult = await SimpleInvoice.DeleteInvoice(data.InvoiceId);
                    if (simpleInvoiceDeleteInvoiceResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception simpleInvoiceDeleteInvoiceException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete Invoice" });
            }
        }
    }
}
