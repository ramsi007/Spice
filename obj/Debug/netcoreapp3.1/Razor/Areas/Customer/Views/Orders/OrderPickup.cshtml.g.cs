#pragma checksum "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Areas\Customer\Views\Orders\OrderPickup.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3a5b5c1733287387f18d0384ccd17e2db75250e1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Customer_Views_Orders_OrderPickup), @"mvc.1.0.view", @"/Areas/Customer/Views/Orders/OrderPickup.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Areas\Customer\Views\_ViewImports.cshtml"
using Spice;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Areas\Customer\Views\_ViewImports.cshtml"
using Spice.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Areas\Customer\Views\_ViewImports.cshtml"
using Spice.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Areas\Customer\Views\_ViewImports.cshtml"
using Spice.Utility;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a5b5c1733287387f18d0384ccd17e2db75250e1", @"/Areas/Customer/Views/Orders/OrderPickup.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"96213e53e60fd06798fb2bbb7019ed1714305795", @"/Areas/Customer/Views/_ViewImports.cshtml")]
    public class Areas_Customer_Views_Orders_OrderPickup : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OrderListViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "OrderPickup", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-class", "btn border", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-class-normal", "btn btn-light", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-class-selected", "btn btn-info active", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn-group float-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Spice.TagHelpers.PageLinkTagHelper __Spice_TagHelpers_PageLinkTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Areas\Customer\Views\Orders\OrderPickup.cshtml"
  
    ViewData["Title"] = "OrderPickup";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"white-Background border\">\r\n    <div class=\"row\">\r\n        <div>\r\n            <h3 class=\"text-info text-center\">Commandes prêtes</h3>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3a5b5c1733287387f18d0384ccd17e2db75250e16413", async() => {
                WriteLiteral("\r\n    <div class=\"row\">\r\n        <div class=\"col-md-11\">\r\n            <div class=\"row\">\r\n                <div class=\"col-md-4\">\r\n                    ");
#nullable restore
#line 20 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Areas\Customer\Views\Orders\OrderPickup.cshtml"
               Write(Html.Editor("SearchName", new { htmlAttributes = new { @class = "form-control mb-3", placeholder = "Nom ..." } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n                <div class=\"col-md-4\">\r\n                    ");
#nullable restore
#line 23 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Areas\Customer\Views\Orders\OrderPickup.cshtml"
               Write(Html.Editor("SearchPhone", new { htmlAttributes = new { @class = "form-control mb-3", placeholder = "Phone ..." } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n                </div>\r\n                <div class=\"col-md-4\">\r\n                    ");
#nullable restore
#line 27 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Areas\Customer\Views\Orders\OrderPickup.cshtml"
               Write(Html.Editor("SearchEmail", new { htmlAttributes = new { @class = "form-control mb-3", placeholder = "Email ..." } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                </div>
            </div>
        </div>

        <div class=""col-md-1"">
            <div class=""row"">
                <button type=""submit"" class=""btn btn-primary form-control mr-3"">
                    <i class=""fas fa-search""></i>
                </button>
            </div>
        </div>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<div>\r\n");
#nullable restore
#line 43 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Areas\Customer\Views\Orders\OrderPickup.cshtml"
     if (Model.Orders.Count == 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h4 class=\"text-danger text-center\">Aucune commande pête pour le moment ... </h4>\r\n");
#nullable restore
#line 46 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Areas\Customer\Views\Orders\OrderPickup.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <table class=\"table table-striped border table-hover\">\r\n            <tr>\r\n                <th>");
#nullable restore
#line 51 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Areas\Customer\Views\Orders\OrderPickup.cshtml"
               Write(Html.DisplayNameFor(m => m.Orders[0].OrderHeader.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 52 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Areas\Customer\Views\Orders\OrderPickup.cshtml"
               Write(Html.DisplayNameFor(m => m.Orders[0].OrderHeader.PickupName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 53 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Areas\Customer\Views\Orders\OrderPickup.cshtml"
               Write(Html.DisplayNameFor(m => m.Orders[0].OrderHeader.ApplicationUser.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 54 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Areas\Customer\Views\Orders\OrderPickup.cshtml"
               Write(Html.DisplayNameFor(m => m.Orders[0].OrderHeader.PickUpTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 55 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Areas\Customer\Views\Orders\OrderPickup.cshtml"
               Write(Html.DisplayNameFor(m => m.Orders[0].OrderHeader.OrderTotal));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>Total de Menu</th>\r\n                <th></th>\r\n            </tr>\r\n");
#nullable restore
#line 59 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Areas\Customer\Views\Orders\OrderPickup.cshtml"
             foreach (var order in Model.Orders)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 62 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Areas\Customer\Views\Orders\OrderPickup.cshtml"
                   Write(Html.DisplayFor(m => order.OrderHeader.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 63 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Areas\Customer\Views\Orders\OrderPickup.cshtml"
                   Write(Html.DisplayFor(m => order.OrderHeader.PickupName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 64 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Areas\Customer\Views\Orders\OrderPickup.cshtml"
                   Write(Html.DisplayFor(m => order.OrderHeader.ApplicationUser.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 65 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Areas\Customer\Views\Orders\OrderPickup.cshtml"
                   Write(Html.DisplayFor(m => order.OrderHeader.PickUpTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 66 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Areas\Customer\Views\Orders\OrderPickup.cshtml"
                   Write(Html.DisplayFor(m => order.OrderHeader.OrderTotal));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 67 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Areas\Customer\Views\Orders\OrderPickup.cshtml"
                   Write(Html.DisplayFor(m => order.OrderDetails.Count));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        <button type=\"button\" class=\"btn btn-success showDetails\"\r\n                                data-id=\"");
#nullable restore
#line 70 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Areas\Customer\Views\Orders\OrderPickup.cshtml"
                                    Write(order.OrderHeader.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-toggle=\"modal\">\r\n                            <i class=\"fas fa-list-alt\"></i>&nbsp;Détails\r\n                        </button>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 75 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Areas\Customer\Views\Orders\OrderPickup.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </table>\r\n");
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3a5b5c1733287387f18d0384ccd17e2db75250e115811", async() => {
                WriteLiteral("\r\n        ");
            }
            );
            __Spice_TagHelpers_PageLinkTagHelper = CreateTagHelper<global::Spice.TagHelpers.PageLinkTagHelper>();
            __tagHelperExecutionContext.Add(__Spice_TagHelpers_PageLinkTagHelper);
#nullable restore
#line 79 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Areas\Customer\Views\Orders\OrderPickup.cshtml"
__Spice_TagHelpers_PageLinkTagHelper.PageModel = Model.PagingInfo;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("page-model", __Spice_TagHelpers_PageLinkTagHelper.PageModel, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 79 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Areas\Customer\Views\Orders\OrderPickup.cshtml"
__Spice_TagHelpers_PageLinkTagHelper.PageClassesEnabled = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("page-classes-enabled", __Spice_TagHelpers_PageLinkTagHelper.PageClassesEnabled, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Spice_TagHelpers_PageLinkTagHelper.PageClass = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Spice_TagHelpers_PageLinkTagHelper.PageClassNormal = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Spice_TagHelpers_PageLinkTagHelper.PageClassSelected = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        <br />\r\n");
#nullable restore
#line 83 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Areas\Customer\Views\Orders\OrderPickup.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>

<div class=""modal fade"" id=""myModal"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
    <div class=""modal-dialog-centered modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header bg-success text-light"">
                <div class=""col-10 offset-1"">
                    <center><h5 class=""modal-title"">Order Details</h5></center>
                </div>
                <div class=""col-1"">
                    <button class=""btn btn-outline-secondary float-right close"" style=""background-color:none;"" aria-label=""Close"" data-dismiss=""modal"">&times;</button>
                </div>
            </div>
            <div class=""modal-body justify-content-center"" id=""myModalContent"">
            </div>
        </div>
    </div>
</div>


");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        var PostBackURL = '/Customer/Orders/GetOrderDetails';
        $(function () {

            $("".showDetails"").click(function () {

                var $buttonClicked = $(this);
                var id = $buttonClicked.attr('data-id');

                $.ajax({
                    type: ""GET"",
                    url: PostBackURL,
                    contentType: ""text/html; charset=utf-8"",
                    data: { ""id"": id },
                    cache: false,
                    dataType: ""html"",
                    success: function (data) {
                        $('#myModalContent').html(data);
                        $('#myModal').modal('show');
                    },
                    error: function () {
                        alert(""Dynamic content load failed"");
                    }
                });
            });
        });

    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OrderListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591