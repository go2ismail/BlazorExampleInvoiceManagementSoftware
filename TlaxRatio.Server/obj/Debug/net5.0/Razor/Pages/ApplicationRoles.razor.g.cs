#pragma checksum "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\ApplicationRoles.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "98c2eba1cef500184794b2fa8ae311cc3daefec9"
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
#line 5 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\ApplicationRoles.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\ApplicationRoles.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\ApplicationRoles.razor"
using TlaxRatio.Models.SimpleInvoice;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\ApplicationRoles.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\ApplicationRoles.razor"
using TlaxRatio.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\ApplicationRoles.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\ApplicationRoles.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/application-roles")]
    public partial class ApplicationRoles : TlaxRatio.Server.Pages.ApplicationRolesComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Radzen.Blazor.RadzenContent>(0);
            __builder.AddAttribute(1, "Container", "main");
            __builder.AddAttribute(2, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Radzen.Blazor.RadzenHeading>(3);
                __builder2.AddAttribute(4, "Size", "H1");
                __builder2.AddAttribute(5, "Text", "Roles");
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(6, "\r\n    ");
                __builder2.OpenElement(7, "div");
                __builder2.AddAttribute(8, "class", "row");
                __builder2.OpenElement(9, "div");
                __builder2.AddAttribute(10, "class", "col-md-12");
                __builder2.OpenComponent<Radzen.Blazor.RadzenButton>(11);
                __builder2.AddAttribute(12, "Disabled", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 20 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\ApplicationRoles.razor"
                                false

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(13, "Icon", "add_circle_outline");
                __builder2.AddAttribute(14, "style", "margin-bottom: 10px");
                __builder2.AddAttribute(15, "Text", "Add");
                __builder2.AddAttribute(16, "Click", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 20 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\ApplicationRoles.razor"
                                                                                                                Button0Click

#line default
#line hidden
#nullable disable
                )));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(17, "\r\n        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGrid<IdentityRole>>(18);
                __builder2.AddAttribute(19, "AllowFiltering", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 22 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\ApplicationRoles.razor"
                                                 true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(20, "AllowPaging", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 22 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\ApplicationRoles.razor"
                                                                    true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(21, "AllowSorting", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 22 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\ApplicationRoles.razor"
                                                                                        true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(22, "Data", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IEnumerable<IdentityRole>>(
#nullable restore
#line 22 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\ApplicationRoles.razor"
                                                                                                     roles

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(23, "Columns", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<IdentityRole>>(24);
                    __builder3.AddAttribute(25, "Property", "Name");
                    __builder3.AddAttribute(26, "Title", "Name");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(27, "\r\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<IdentityRole>>(28);
                    __builder3.AddAttribute(29, "Filterable", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 26 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\ApplicationRoles.razor"
                                                               false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(30, "Sortable", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 26 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\ApplicationRoles.razor"
                                                                                false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(31, "Visible", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 26 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\ApplicationRoles.razor"
                                                                                                false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(32, "Width", "70px");
                    __builder3.AddAttribute(33, "Template", (Microsoft.AspNetCore.Components.RenderFragment<IdentityRole>)((identityRole) => (__builder4) => {
                        __builder4.OpenComponent<Radzen.Blazor.RadzenButton>(34);
                        __builder4.AddAttribute(35, "ButtonStyle", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 28 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\ApplicationRoles.razor"
                                           ButtonStyle.Danger

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(36, "Icon", "close");
                        __builder4.AddAttribute(37, "Size", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonSize>(
#nullable restore
#line 28 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\ApplicationRoles.razor"
                                                                                  ButtonSize.Small

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(38, "Click", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 28 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\ApplicationRoles.razor"
                                                                                                             (args) =>GridDeleteButtonClick(args, identityRole)

#line default
#line hidden
#nullable disable
                        )));
                        __builder4.AddEventStopPropagationAttribute(39, "onclick", 
#nullable restore
#line 28 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\ApplicationRoles.razor"
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
                __builder2.AddComponentReferenceCapture(40, (__value) => {
#nullable restore
#line 22 "D:\bbGIT\bbteam17\BlazorExampleInvoiceManagementSoftware\TlaxRatio.Server\Pages\ApplicationRoles.razor"
                          grid0 = (Radzen.Blazor.RadzenGrid<IdentityRole>)__value;

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
