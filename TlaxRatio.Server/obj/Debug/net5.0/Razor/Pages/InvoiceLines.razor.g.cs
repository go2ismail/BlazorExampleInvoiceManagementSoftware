#pragma checksum "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\InvoiceLines.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bacf3f321a4018e053dbbd63190f0507d28bce95"
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
#line 5 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\InvoiceLines.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\InvoiceLines.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\InvoiceLines.razor"
using TlaxRatio.Models.SimpleInvoice;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\InvoiceLines.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\InvoiceLines.razor"
using TlaxRatio.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\InvoiceLines.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\InvoiceLines.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/invoice-lines")]
    public partial class InvoiceLines : TlaxRatio.Server.Pages.InvoiceLinesComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Radzen.Blazor.RadzenContent>(0);
            __builder.AddAttribute(1, "Container", "main");
            __builder.AddAttribute(2, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Radzen.Blazor.RadzenHeading>(3);
                __builder2.AddAttribute(4, "Size", "H1");
                __builder2.AddAttribute(5, "Text", "Invoice Lines");
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
#line 20 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\InvoiceLines.razor"
                                                                                               Button0Click

#line default
#line hidden
#nullable disable
                )));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(16, "\r\n        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenSplitButton>(17);
                __builder2.AddAttribute(18, "Icon", "get_app");
                __builder2.AddAttribute(19, "style", "margin-left: 10px; margin-bottom: 10px");
                __builder2.AddAttribute(20, "Text", "Export");
                __builder2.AddAttribute(21, "Click", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Radzen.Blazor.RadzenSplitButtonItem>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Radzen.Blazor.RadzenSplitButtonItem>(this, 
#nullable restore
#line 22 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\InvoiceLines.razor"
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
#line 30 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\InvoiceLines.razor"
                                                                                                                                     async(args) => {search = $"{args.Value}";await grid0.GoToPage(0);await Load();}

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(36, "\r\n        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGrid<TlaxRatio.Models.SimpleInvoice.InvoiceLine>>(37);
                __builder2.AddAttribute(38, "AllowFiltering", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 32 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\InvoiceLines.razor"
                                                 true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(39, "FilterMode", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.FilterMode>(
#nullable restore
#line 32 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\InvoiceLines.razor"
                                                                   FilterMode.Advanced

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(40, "AllowPaging", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 32 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\InvoiceLines.razor"
                                                                                                     true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(41, "AllowSorting", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 32 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\InvoiceLines.razor"
                                                                                                                         true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(42, "Data", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IEnumerable<TlaxRatio.Models.SimpleInvoice.InvoiceLine>>(
#nullable restore
#line 32 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\InvoiceLines.razor"
                                                                                                                                      getInvoiceLinesResult

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(43, "RowSelect", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<TlaxRatio.Models.SimpleInvoice.InvoiceLine>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<TlaxRatio.Models.SimpleInvoice.InvoiceLine>(this, 
#nullable restore
#line 32 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\InvoiceLines.razor"
                                                                                                                                                                                                                            Grid0RowSelect

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(44, "Columns", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<TlaxRatio.Models.SimpleInvoice.InvoiceLine>>(45);
                    __builder3.AddAttribute(46, "Property", "InvoiceLineId");
                    __builder3.AddAttribute(47, "Title", "Invoice Line Id");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(48, "\r\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<TlaxRatio.Models.SimpleInvoice.InvoiceLine>>(49);
                    __builder3.AddAttribute(50, "Property", "InvoiceId");
                    __builder3.AddAttribute(51, "SortProperty", "Invoice.InvoiceNumber");
                    __builder3.AddAttribute(52, "FilterProperty", "Invoice.InvoiceNumber");
                    __builder3.AddAttribute(53, "Title", "Invoice");
                    __builder3.AddAttribute(54, "Template", (Microsoft.AspNetCore.Components.RenderFragment<TlaxRatio.Models.SimpleInvoice.InvoiceLine>)((data) => (__builder4) => {
#nullable restore
#line 38 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\InvoiceLines.razor"
__builder4.AddContent(55, data.Invoice?.InvoiceNumber);

#line default
#line hidden
#nullable disable
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(56, "\r\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<TlaxRatio.Models.SimpleInvoice.InvoiceLine>>(57);
                    __builder3.AddAttribute(58, "Property", "ProductId");
                    __builder3.AddAttribute(59, "SortProperty", "Product.Name");
                    __builder3.AddAttribute(60, "FilterProperty", "Product.Name");
                    __builder3.AddAttribute(61, "Title", "Product");
                    __builder3.AddAttribute(62, "Template", (Microsoft.AspNetCore.Components.RenderFragment<TlaxRatio.Models.SimpleInvoice.InvoiceLine>)((data) => (__builder4) => {
#nullable restore
#line 43 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\InvoiceLines.razor"
__builder4.AddContent(63, data.Product?.Name);

#line default
#line hidden
#nullable disable
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(64, "\r\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<TlaxRatio.Models.SimpleInvoice.InvoiceLine>>(65);
                    __builder3.AddAttribute(66, "Property", "Qty");
                    __builder3.AddAttribute(67, "Title", "Qty");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(68, "\r\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<TlaxRatio.Models.SimpleInvoice.InvoiceLine>>(69);
                    __builder3.AddAttribute(70, "Property", "UnitPrice");
                    __builder3.AddAttribute(71, "Title", "Unit Price");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(72, "\r\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<TlaxRatio.Models.SimpleInvoice.InvoiceLine>>(73);
                    __builder3.AddAttribute(74, "Property", "Total");
                    __builder3.AddAttribute(75, "Title", "Total");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(76, "\r\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<TlaxRatio.Models.SimpleInvoice.InvoiceLine>>(77);
                    __builder3.AddAttribute(78, "Filterable", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 52 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\InvoiceLines.razor"
                                                                                             false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(79, "Sortable", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 52 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\InvoiceLines.razor"
                                                                                                              false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(80, "Width", "70px");
                    __builder3.AddAttribute(81, "TextAlign", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.TextAlign>(
#nullable restore
#line 52 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\InvoiceLines.razor"
                                                                                                                                             TextAlign.Center

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(82, "Template", (Microsoft.AspNetCore.Components.RenderFragment<TlaxRatio.Models.SimpleInvoice.InvoiceLine>)((TlaxRatioModelsSimpleInvoiceInvoiceLine) => (__builder4) => {
                        __builder4.OpenComponent<Radzen.Blazor.RadzenButton>(83);
                        __builder4.AddAttribute(84, "ButtonStyle", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 54 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\InvoiceLines.razor"
                                           ButtonStyle.Danger

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(85, "Icon", "close");
                        __builder4.AddAttribute(86, "Size", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonSize>(
#nullable restore
#line 54 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\InvoiceLines.razor"
                                                                                  ButtonSize.Small

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(87, "Click", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 54 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\InvoiceLines.razor"
                                                                                                             (args) =>GridDeleteButtonClick(args, TlaxRatioModelsSimpleInvoiceInvoiceLine)

#line default
#line hidden
#nullable disable
                        )));
                        __builder4.AddEventStopPropagationAttribute(88, "onclick", 
#nullable restore
#line 54 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\InvoiceLines.razor"
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
                __builder2.AddComponentReferenceCapture(89, (__value) => {
#nullable restore
#line 32 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\InvoiceLines.razor"
                          grid0 = (Radzen.Blazor.RadzenGrid<TlaxRatio.Models.SimpleInvoice.InvoiceLine>)__value;

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