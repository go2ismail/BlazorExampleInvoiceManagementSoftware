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
using SimpleInvoiceManagementSoftware.Models.SimpleInvoice;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SimpleInvoiceManagementSoftware.Models;

namespace SimpleInvoiceManagementSoftware.Pages
{
    public partial class ProductsComponent : ComponentBase
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
        protected SimpleInvoiceService SimpleInvoice { get; set; }
        protected RadzenGrid<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Product> grid0;

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

        IEnumerable<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Product> _getProductsResult;
        protected IEnumerable<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Product> getProductsResult
        {
            get
            {
                return _getProductsResult;
            }
            set
            {
                if (!object.Equals(_getProductsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getProductsResult", NewValue = value, OldValue = _getProductsResult };
                    _getProductsResult = value;
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

            var simpleInvoiceGetProductsResult = await SimpleInvoice.GetProducts(new Query() { Filter = $@"i => i.Name.Contains(@0) || i.Description.Contains(@1)", FilterParameters = new object[] { search, search } });
            getProductsResult = simpleInvoiceGetProductsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddProduct>("Add Product", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await SimpleInvoice.ExportProductsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "ProductId,Name,Description,UnitPrice" }, $"Products");

            }

            if (args == null || args.Value == "xlsx")
            {
                await SimpleInvoice.ExportProductsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "ProductId,Name,Description,UnitPrice" }, $"Products");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Product args)
        {
            var dialogResult = await DialogService.OpenAsync<EditProduct>("Edit Product", new Dictionary<string, object>() { {"ProductId", args.ProductId} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var simpleInvoiceDeleteProductResult = await SimpleInvoice.DeleteProduct(data.ProductId);
                    if (simpleInvoiceDeleteProductResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception simpleInvoiceDeleteProductException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete Product" });
            }
        }
    }
}
