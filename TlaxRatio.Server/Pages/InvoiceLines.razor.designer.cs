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
    public partial class InvoiceLinesComponent : ComponentBase
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
        protected RadzenGrid<InvoiceLine> grid0;

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

        IEnumerable<InvoiceLine> _getInvoiceLinesResult;
        protected IEnumerable<InvoiceLine> getInvoiceLinesResult
        {
            get
            {
                return _getInvoiceLinesResult;
            }
            set
            {
                if (!object.Equals(_getInvoiceLinesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getInvoiceLinesResult", NewValue = value, OldValue = _getInvoiceLinesResult };
                    _getInvoiceLinesResult = value;
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

            var simpleInvoiceGetInvoiceLinesResult = await SimpleInvoice.GetInvoiceLines(new Query() { Expand = "Invoice,Product" });
            getInvoiceLinesResult = simpleInvoiceGetInvoiceLinesResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddInvoiceLine>("Add Invoice Line", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await SimpleInvoice.ExportInvoiceLinesToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "Invoice,Product", Select = "InvoiceLineId,Invoice.InvoiceNumber,Product.Name,Qty,UnitPrice,Total" }, $"Invoice Lines");

            }

            if (args == null || args.Value == "xlsx")
            {
                await SimpleInvoice.ExportInvoiceLinesToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "Invoice,Product", Select = "InvoiceLineId,Invoice.InvoiceNumber,Product.Name,Qty,UnitPrice,Total" }, $"Invoice Lines");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(InvoiceLine args)
        {
            var dialogResult = await DialogService.OpenAsync<EditInvoiceLine>("Edit Invoice Line", new Dictionary<string, object>() { {"InvoiceLineId", args.InvoiceLineId} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var simpleInvoiceDeleteInvoiceLineResult = await SimpleInvoice.DeleteInvoiceLine(data.InvoiceLineId);
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
    }
}
