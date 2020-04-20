#pragma checksum "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Chart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0420998fa82aa81bb1ece9532b19feae7d72be8c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Chart_Index), @"mvc.1.0.view", @"/Views/Chart/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0420998fa82aa81bb1ece9532b19feae7d72be8c", @"/Views/Chart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"395ba230260e5a70cc402d960fb8f71197c81e6f", @"/Views/_ViewImports.cshtml")]
    public class Views_Chart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Entities.StatisticRepo.Reports>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Chart\Index.cshtml"
  
    var XLabels = Newtonsoft.Json.JsonConvert.SerializeObject(Model.Select(x => x.Date.ToString("MMMM", System.Globalization.CultureInfo.CreateSpecificCulture("fr"))+" ").ToList());
    var YValues = Newtonsoft.Json.JsonConvert.SerializeObject(Model.Select(x => x.Debit).ToList());
    var YValuesCrd = Newtonsoft.Json.JsonConvert.SerializeObject(Model.Select(x => x.Creditor).ToList());
    ViewData["Title"] = "Bar Chart";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"

    <section class=""content"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-md-12"">
                 
                    <!-- BAR CHART -->
                    <div class=""card card-dark"">
                        <div class=""card-header"">
                            <h3 class=""card-title"">Statistique Mensuels</h3>

                            <div class=""card-tools"">
                                <button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse"">
                                    <i class=""fas fa-minus""></i>
                                </button>
                                <button type=""button"" class=""btn btn-tool"" data-card-widget=""remove""><i class=""fas fa-times""></i></button>
                            </div>
                        </div>
                        <div class=""card-body"">
                            <div class=""chart"">
                                <canvas id=""barChart"" style=""min-heigh");
            WriteLiteral(@"t: 400px; height: 400px; max-height: 400px; max-width: 100%;""></canvas>
                            </div>
                        </div>
                        <!-- /.card-body -->
                    </div>
                    <!-- /.card -->
            

                </div>
                <!-- /.col (RIGHT) -->
            </div>
            <!-- /.row -->
        </div><!-- /.container-fluid -->
    </section>





");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

                        <script>
        $(function () {
            /* ChartJS
             * -------
             * Here we will create a few charts using ChartJS
             */

            //--------------
            //- AREA CHART -
            //--------------

            // Get context with jQuery - using jQuery's .get() method.
            
            var areaChartData = {
                labels:");
#nullable restore
#line 66 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Chart\Index.cshtml"
                  Write(Html.Raw(XLabels));

#line default
#line hidden
#nullable disable
                WriteLiteral(@",
                datasets: [
                    {
                        label: 'Revenus',
                        backgroundColor: 'rgba(60,141,188,0.9)',
                        borderColor: 'rgba(60,141,188,0.8)',
                        pointRadius: false,
                        pointColor: '#3b8bba',
                        pointStrokeColor: 'rgba(60,141,188,1)',
                        pointHighlightFill: '#fff',
                        pointHighlightStroke: 'rgba(60,141,188,1)',
                        data:");
#nullable restore
#line 77 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Chart\Index.cshtml"
                        Write(Html.Raw(YValues));

#line default
#line hidden
#nullable disable
                WriteLiteral(@",
                    },
                    {
                        label: 'Dépenses',
                        backgroundColor: 'rgba(210, 214, 222, 1)',
                        borderColor: 'rgba(210, 214, 222, 1)',
                        pointRadius: false,
                        pointColor: 'rgba(210, 214, 222, 1)',
                        pointStrokeColor: '#c1c7d1',
                        pointHighlightFill: '#fff',
                        pointHighlightStroke: 'rgba(220,220,220,1)',
                        data: ");
#nullable restore
#line 88 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Chart\Index.cshtml"
                         Write(Html.Raw(YValuesCrd));

#line default
#line hidden
#nullable disable
                WriteLiteral(@",
                    },
                ]
            }
          
               //-------------
            //- BAR CHART -
            //-------------
            var barChartCanvas = $('#barChart').get(0).getContext('2d')
            var barChartData = jQuery.extend(true, {}, areaChartData)
            var temp0 = areaChartData.datasets[0]
            var temp1 = areaChartData.datasets[1]
            barChartData.datasets[0] = temp1
            barChartData.datasets[1] = temp0

            var barChartOptions = {
                responsive: true,
                maintainAspectRatio: false,
                datasetFill: false
            }

            var barChart = new Chart(barChartCanvas, {
                type: 'bar',
                data: barChartData,
                options: barChartOptions
            })

          
        })
          </script>

      ");
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Entities.StatisticRepo.Reports>> Html { get; private set; }
    }
}
#pragma warning restore 1591
