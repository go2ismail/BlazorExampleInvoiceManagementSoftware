#pragma checksum "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "06615cca4ea925cfc5865195f9d89cdb61fd22bb"
// <auto-generated/>
#pragma warning disable 1591
namespace TlaxRatio.Server.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\_Imports.razor"
using TlaxRatio.Layouts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\_Imports.razor"
using TlaxRatio.Server.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\_Imports.razor"
using TlaxRatio.Server.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
using TlaxRatio.Models.SimpleInvoice;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
using TlaxRatio.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/invoices")]
    public partial class Invoices : TlaxRatio.Server.Pages.InvoicesComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Radzen.Blazor.RadzenContent>(0);
            __builder.AddAttribute(1, "Container", "main");
            __builder.AddAttribute(2, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Radzen.Blazor.RadzenHeading>(3);
                __builder2.AddAttribute(4, "Size", "H1");
                __builder2.AddAttribute(5, "Text", "Invoices");
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(6, "\r\n    ");
                __builder2.OpenElement(7, "div");
                __builder2.AddAttribute(8, "class", "row");
                __builder2.OpenElement(9, "div");
                __builder2.AddAttribute(10, "class", "col-md-12");
                __builder2.OpenComponent<Radzen.Blazor.RadzenButton>(11);
                __builder2.AddAttribute(12, "Icon", "add_circle_outline");
                __builder2.AddAttribute(13, "style", "margin-bottom: 10px");
                __builder2.AddAttribute(14, "Text", "Add");
                __builder2.AddAttribute(15, "Click", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 20 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
                                                                                               Button0Click

#line default
#line hidden
#nullable disable
                )));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(16, "\r\n        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenSplitButton>(17);
                __builder2.AddAttribute(18, "Icon", "get_app");
                __builder2.AddAttribute(19, "style", "margin-bottom: 10px; margin-left: 10px");
                __builder2.AddAttribute(20, "Text", "Export");
                __builder2.AddAttribute(21, "Click", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Radzen.Blazor.RadzenSplitButtonItem>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Radzen.Blazor.RadzenSplitButtonItem>(this, 
#nullable restore
#line 22 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
                                                                                                               Splitbutton0Click

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(22, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<Radzen.Blazor.RadzenSplitButtonItem>(23);
                    __builder3.AddAttribute(24, "Text", "Excel");
                    __builder3.AddAttribute(25, "Value", "xlsx");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(26, "\r\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenSplitButtonItem>(27);
                    __builder3.AddAttribute(28, "Text", "CSV");
                    __builder3.AddAttribute(29, "Value", "csv");
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(30, "\r\n        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenTextBox>(31);
                __builder2.AddAttribute(32, "Placeholder", "Search ...");
                __builder2.AddAttribute(33, "style", "display: block; margin-bottom: 10px; width: 100%");
                __builder2.AddAttribute(34, "Name", "Textbox0");
                __builder2.AddAttribute(35, "oninput", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 30 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
                                                                                                                                     async(args) => {search = $"{args.Value}";await grid0.GoToPage(0);await Load();}

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(36, "\r\n        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGrid<TlaxRatio.Models.SimpleInvoice.Invoice>>(37);
                __builder2.AddAttribute(38, "AllowFiltering", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 32 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
                                                 true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(39, "AllowPaging", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 32 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
                                                                    true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(40, "AllowSorting", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 32 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
                                                                                        true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(41, "Data", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IEnumerable<TlaxRatio.Models.SimpleInvoice.Invoice>>(
#nullable restore
#line 32 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
                                                                                                     getInvoicesResult

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(42, "FilterMode", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.FilterMode>(
#nullable restore
#line 32 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
                                                                                                                                    FilterMode.Advanced

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(43, "RowSelect", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<TlaxRatio.Models.SimpleInvoice.Invoice>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<TlaxRatio.Models.SimpleInvoice.Invoice>(this, 
#nullable restore
#line 32 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
                                                                                                                                                                                                                    Grid0RowSelect

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(44, "Columns", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<TlaxRatio.Models.SimpleInvoice.Invoice>>(45);
                    __builder3.AddAttribute(46, "Property", "InvoiceId");
                    __builder3.AddAttribute(47, "Title", "Invoice Id");
                    __builder3.AddAttribute(48, "Visible", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 34 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
                                                                                                                              false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(49, "\r\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<TlaxRatio.Models.SimpleInvoice.Invoice>>(50);
                    __builder3.AddAttribute(51, "Property", "InvoiceNumber");
                    __builder3.AddAttribute(52, "Title", "Invoice Number");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(53, "\r\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<TlaxRatio.Models.SimpleInvoice.Invoice>>(54);
                    __builder3.AddAttribute(55, "FilterProperty", "Company.Name");
                    __builder3.AddAttribute(56, "Property", "CompanyId");
                    __builder3.AddAttribute(57, "SortProperty", "Company.Name");
                    __builder3.AddAttribute(58, "Title", "Company");
                    __builder3.AddAttribute(59, "Template", (Microsoft.AspNetCore.Components.RenderFragment<TlaxRatio.Models.SimpleInvoice.Invoice>)((data) => (__builder4) => {
#nullable restore
#line 40 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
__builder4.AddContent(60, data.Company?.Name);

#line default
#line hidden
#nullable disable
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(61, "\r\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<TlaxRatio.Models.SimpleInvoice.Invoice>>(62);
                    __builder3.AddAttribute(63, "FilterProperty", "Customer.Name");
                    __builder3.AddAttribute(64, "Property", "CustomerId");
                    __builder3.AddAttribute(65, "SortProperty", "Customer.Name");
                    __builder3.AddAttribute(66, "Title", "Customer");
                    __builder3.AddAttribute(67, "Template", (Microsoft.AspNetCore.Components.RenderFragment<TlaxRatio.Models.SimpleInvoice.Invoice>)((data) => (__builder4) => {
#nullable restore
#line 45 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
__builder4.AddContent(68, data.Customer?.Name);

#line default
#line hidden
#nullable disable
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(69, "\r\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<TlaxRatio.Models.SimpleInvoice.Invoice>>(70);
                    __builder3.AddAttribute(71, "FormatString", "{0:yyyy-MM-dd}");
                    __builder3.AddAttribute(72, "Property", "InvoiceDate");
                    __builder3.AddAttribute(73, "Title", "Invoice Date");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(74, "\r\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<TlaxRatio.Models.SimpleInvoice.Invoice>>(75);
                    __builder3.AddAttribute(76, "FormatString", "{0:yyyy-MM-dd}");
                    __builder3.AddAttribute(77, "Property", "InvoiceDueDate");
                    __builder3.AddAttribute(78, "Title", "Invoice Due Date");
                    __builder3.AddAttribute(79, "Visible", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 50 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
                                                                                                                                                                       false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(80, "\r\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<TlaxRatio.Models.SimpleInvoice.Invoice>>(81);
                    __builder3.AddAttribute(82, "FilterProperty", "Tax.Name");
                    __builder3.AddAttribute(83, "Property", "TaxId");
                    __builder3.AddAttribute(84, "SortProperty", "Tax.Name");
                    __builder3.AddAttribute(85, "Title", "Tax");
                    __builder3.AddAttribute(86, "Visible", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 52 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
                                                                                                                                                                     false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(87, "Template", (Microsoft.AspNetCore.Components.RenderFragment<TlaxRatio.Models.SimpleInvoice.Invoice>)((data) => (__builder4) => {
#nullable restore
#line 54 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
__builder4.AddContent(88, data.Tax?.Name);

#line default
#line hidden
#nullable disable
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(89, "\r\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<TlaxRatio.Models.SimpleInvoice.Invoice>>(90);
                    __builder3.AddAttribute(91, "Property", "Total");
                    __builder3.AddAttribute(92, "Title", "Total");
                    __builder3.AddAttribute(93, "Visible", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 57 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
                                                                                                                     false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(94, "\r\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<TlaxRatio.Models.SimpleInvoice.Invoice>>(95);
                    __builder3.AddAttribute(96, "Property", "Discount");
                    __builder3.AddAttribute(97, "Title", "Discount");
                    __builder3.AddAttribute(98, "Visible", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 59 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
                                                                                                                           false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(99, "\r\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<TlaxRatio.Models.SimpleInvoice.Invoice>>(100);
                    __builder3.AddAttribute(101, "Property", "BeforeTax");
                    __builder3.AddAttribute(102, "Title", "Before Tax");
                    __builder3.AddAttribute(103, "Visible", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 61 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
                                                                                                                              false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(104, "\r\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<TlaxRatio.Models.SimpleInvoice.Invoice>>(105);
                    __builder3.AddAttribute(106, "Property", "TaxAmount");
                    __builder3.AddAttribute(107, "Title", "Tax Amount");
                    __builder3.AddAttribute(108, "Visible", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 63 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
                                                                                                                              false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(109, "\r\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<TlaxRatio.Models.SimpleInvoice.Invoice>>(110);
                    __builder3.AddAttribute(111, "Property", "GrandTotal");
                    __builder3.AddAttribute(112, "Title", "Grand Total");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(113, "\r\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<TlaxRatio.Models.SimpleInvoice.Invoice>>(114);
                    __builder3.AddAttribute(115, "Filterable", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 67 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
                                                                                         false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(116, "Sortable", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 67 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
                                                                                                          false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(117, "TextAlign", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.TextAlign>(
#nullable restore
#line 67 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
                                                                                                                            TextAlign.Center

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(118, "Width", "70px");
                    __builder3.AddAttribute(119, "Template", (Microsoft.AspNetCore.Components.RenderFragment<TlaxRatio.Models.SimpleInvoice.Invoice>)((TlaxRatioModelsSimpleInvoiceInvoice) => (__builder4) => {
                        __builder4.OpenComponent<Radzen.Blazor.RadzenButton>(120);
                        __builder4.AddAttribute(121, "ButtonStyle", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 69 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
                                           ButtonStyle.Danger

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(122, "Icon", "close");
                        __builder4.AddAttribute(123, "Size", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonSize>(
#nullable restore
#line 69 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
                                                                                  ButtonSize.Small

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(124, "Click", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 69 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
                                                                                                             (args) =>GridDeleteButtonClick(args, TlaxRatioModelsSimpleInvoiceInvoice)

#line default
#line hidden
#nullable disable
                        )));
                        __builder4.AddEventStopPropagationAttribute(125, "onclick", 
#nullable restore
#line 69 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
                                                                                                                                                                                                                   true

#line default
#line hidden
#nullable disable
                        );
                        __builder4.CloseComponent();
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.AddComponentReferenceCapture(126, (__value) => {
#nullable restore
#line 32 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\Invoices.razor"
                          grid0 = (Radzen.Blazor.RadzenGrid<TlaxRatio.Models.SimpleInvoice.Invoice>)__value;

#line default
#line hidden
#nullable disable
                }
                );
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591