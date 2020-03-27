#pragma checksum "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Statistics\GetByDate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5e41229689328ae6e12361173498311d93f50e48"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Statistics_GetByDate), @"mvc.1.0.view", @"/Views/Statistics/GetByDate.cshtml")]
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
#line 1 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\_ViewImports.cshtml"
using MyApps;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\_ViewImports.cshtml"
using MyApps.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e41229689328ae6e12361173498311d93f50e48", @"/Views/Statistics/GetByDate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"395ba230260e5a70cc402d960fb8f71197c81e6f", @"/Views/_ViewImports.cshtml")]
    public class Views_Statistics_GetByDate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Entities.StatisticRepo.Reports>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Statistics\GetByDate.cshtml"
  
    ViewData["Title"] = "GetByDate";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    <div class=\"row\">\r\n        <div class=\"col-lg-3 col-6\">\r\n            <!-- small box -->\r\n            <div class=\"small-box bg-info\">\r\n                <div class=\"inner\">\r\n                    <h3 id=\"headPrice\">");
#nullable restore
#line 13 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Statistics\GetByDate.cshtml"
                                  Write(ViewBag.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>

                    <p>Total des dépenses</p>
                </div>
                <div class=""icon"">
                    <i class=""ion ion-bag""></i>
                </div>
                <a href=""#"" class=""small-box-footer"">More info <i class=""fas fa-arrow-circle-right""></i></a>
            </div>
        </div>
        <!-- ./col -->
        <div class=""col-lg-3 col-6"">
            <!-- small box -->
            <div class=""small-box bg-success"">
                <div class=""inner"">
                    <h3>");
#nullable restore
#line 28 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Statistics\GetByDate.cshtml"
                   Write(ViewBag.count);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>

                    <p>Nombre des dépenses</p>
                </div>
                <div class=""icon"">
                    <i class=""ion ion-stats-bars""></i>
                </div>
                <a href=""#"" class=""small-box-footer"">More info <i class=""fas fa-arrow-circle-right""></i></a>
            </div>
        </div>
        <!-- ./col -->
        <div class=""col-lg-3 col-6"">
            <!-- small box -->
            <div class=""small-box bg-warning"">
                <div class=""inner"">
                    <h3>");
#nullable restore
#line 43 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Statistics\GetByDate.cshtml"
                   Write(ViewBag.CountCustomer);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>

                    <p>Total des clients</p>
                </div>
                <div class=""icon"">
                    <i class=""ion ion-person-add""></i>
                </div>
                <a href=""#"" class=""small-box-footer"">More info <i class=""fas fa-arrow-circle-right""></i></a>
            </div>
        </div>
        <!-- ./col -->
        <div class=""col-lg-3 col-6"">
            <!-- small box -->
            <div class=""small-box bg-danger"">
                <div class=""inner"">
                    <h3>");
#nullable restore
#line 58 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Statistics\GetByDate.cshtml"
                   Write(ViewBag.PaymentCustomer);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>

                    <p>Revenu Total</p>
                </div>
                <div class=""icon"">
                    <i class=""ion ion-pie-graph""></i>
                </div>
                <a href=""#"" class=""small-box-footer"">More info <i class=""fas fa-arrow-circle-right""></i></a>
            </div>
        </div>
        <!-- ./col -->
        <div class=""container"">
            <div class=""row"">
                <div class=""col-12  mt-3"">
                    <div class=""card "">
                        <div class=""card-header bg-dark"">
                            <h2 class=""card-title display-2"">Rapport</h2>

                        </div>

                        <!-- /.card-header -->
                        <div class=""card-body"">
                            <div class=""table-responsive"">
                                <table id=""example2"" class=""table table-hover table-bordered  text-center"">
                                    <thead class=""bg-dark"">
                   ");
            WriteLiteral("                     <tr>\r\n                                            <th>\r\n                                                ");
#nullable restore
#line 85 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Statistics\GetByDate.cshtml"
                                           Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </th>\r\n                                            <th>\r\n                                                ");
#nullable restore
#line 88 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Statistics\GetByDate.cshtml"
                                           Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </th>\r\n                                            <th>\r\n                                                ");
#nullable restore
#line 91 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Statistics\GetByDate.cshtml"
                                           Write(Html.DisplayNameFor(model => model.Debit));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </th>\r\n                                            <th>\r\n                                                ");
#nullable restore
#line 94 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Statistics\GetByDate.cshtml"
                                           Write(Html.DisplayNameFor(model => model.Creditor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </th>\r\n\r\n                                        </tr>\r\n                                    </thead>\r\n                                    <tbody>\r\n");
#nullable restore
#line 100 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Statistics\GetByDate.cshtml"
                                           
                                             decimal debit =0;
                                             decimal creditor =0;
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 104 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Statistics\GetByDate.cshtml"
                                         foreach (var item in Model)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td>\r\n                                                    ");
#nullable restore
#line 108 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Statistics\GetByDate.cshtml"
                                               Write(Html.DisplayFor(modelItem => item.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </td>\r\n                                                <td>\r\n                                                    ");
#nullable restore
#line 111 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Statistics\GetByDate.cshtml"
                                               Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </td>\r\n                                                <td>\r\n                                                    ");
#nullable restore
#line 114 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Statistics\GetByDate.cshtml"
                                               Write(Html.DisplayFor(modelItem => item.Debit));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </td>\r\n                                                <td>\r\n                                                    ");
#nullable restore
#line 117 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Statistics\GetByDate.cshtml"
                                               Write(Html.DisplayFor(modelItem => item.Creditor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </td>\r\n");
#nullable restore
#line 119 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Statistics\GetByDate.cshtml"
                                                   
                                                   debit += item.Debit;
                                                   creditor += item.Creditor;
                                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            </tr>\r\n");
#nullable restore
#line 124 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Statistics\GetByDate.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <tr>
                                        <td colspan=""2"" class=""bg-orange"">
                                            <h3 class=""text-light"">Total</h3>
                                        </td>

                                        <td colspan=""2"">
");
#nullable restore
#line 131 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Statistics\GetByDate.cshtml"
                                              
                                                var result = debit - creditor;
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 134 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Statistics\GetByDate.cshtml"
                                             if (result < 0)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <h4 class=\"text-danger\"> ");
#nullable restore
#line 136 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Statistics\GetByDate.cshtml"
                                                                    Write(result);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n");
#nullable restore
#line 137 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Statistics\GetByDate.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <h4 class=\"text-success\"> ");
#nullable restore
#line 140 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Statistics\GetByDate.cshtml"
                                                                     Write(result);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n");
#nullable restore
#line 141 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Statistics\GetByDate.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                        </td>
                                    </tr>
                                    </tbody>
                                </table>
                            </div>

                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>



");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Entities.StatisticRepo.Reports>> Html { get; private set; }
    }
}
#pragma warning restore 1591
