#pragma checksum "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Portfolio\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "afffb5a1d9c7b99575000af8c32d2f5c706ddc88"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Portfolio_Index), @"mvc.1.0.view", @"/Views/Portfolio/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"afffb5a1d9c7b99575000af8c32d2f5c706ddc88", @"/Views/Portfolio/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92babec59efb94aaf7278b725723179c0316171f", @"/Views/_ViewImports.cshtml")]
    public class Views_Portfolio_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Entities.Portfolio.Portfolio>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-block w-100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/portfolio/CrossFit (2).jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("..."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Portfolio\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_LoginPortfolio.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div id=""carouselExampleIndicators"" class=""carousel slide"" data-ride=""carousel"">
    <ol class=""carousel-indicators"">
        <li data-target=""#carouselExampleIndicators"" data-slide-to=""0"" class=""active""></li>
        <li data-target=""#carouselExampleIndicators"" data-slide-to=""1""></li>
        <li data-target=""#carouselExampleIndicators"" data-slide-to=""2""></li>

    </ol>
    <div class=""carousel-inner"">
        <div class=""carousel-item active"">

            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "afffb5a1d9c7b99575000af8c32d2f5c706ddc886405", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n        </div>\n        <div class=\"carousel-item\">\n\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "afffb5a1d9c7b99575000af8c32d2f5c706ddc887585", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n        </div>\n        <div class=\"carousel-item\">\n\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "afffb5a1d9c7b99575000af8c32d2f5c706ddc888765", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

        </div>

    </div>
    <a class=""carousel-control-prev"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""prev"">
        <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
        <span class=""sr-only"">Previous</span>
    </a>
    <a class=""carousel-control-next"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""next"">
        <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
        <span class=""sr-only"">Next</span>
    </a>
</div>
<br />
<div class=""container marketing"">

    <!-- Three columns of text below the carousel -->
    <div class=""row"">
        <div class=""col-lg-4"">
            <svg class=""bd-placeholder-img rounded-circle"" width=""140"" height=""140"" xmlns=""http://www.w3.org/2000/svg"" preserveAspectRatio=""xMidYMid slice"" focusable=""false"" role=""img"" aria-label=""Placeholder: 140x140""><title>Placeholder</title><rect width=""100%"" height=""100%"" fill=""#777"" /><text x=""50%"" y=""50%"" fill=""#777"" dy="".3em"">140x140</text></svg>
            <h2>");
            WriteLiteral(@"Help</h2>
            <p>Donec sed odio dui. Etiam porta sem malesuada magna mollis euismod. Nullam id dolor id nibh ultricies vehicula ut id elit. Morbi leo risus, porta ac consectetur ac, vestibulum at eros. Praesent commodo cursus magna.</p>

        </div><!-- /.col-lg-4 -->
        <div class=""col-lg-4"">
            <svg class=""bd-placeholder-img rounded-circle"" width=""140"" height=""140"" xmlns=""http://www.w3.org/2000/svg"" preserveAspectRatio=""xMidYMid slice"" focusable=""false"" role=""img"" aria-label=""Placeholder: 140x140""><title>Placeholder</title><rect width=""100%"" height=""100%"" fill=""#777"" /><text x=""50%"" y=""50%"" fill=""#777"" dy="".3em"">140x140</text></svg>
            <h2>advice</h2>
            <p>Duis mollis, est non commodo luctus, nisi erat porttitor ligula, eget lacinia odio sem nec elit. Cras mattis consectetur purus sit amet fermentum. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh.</p>

        </div><!-- /.col-lg-4 -->
        <div class=""col-lg-4"">
            <svg class=");
            WriteLiteral(@"""bd-placeholder-img rounded-circle"" width=""140"" height=""140"" xmlns=""http://www.w3.org/2000/svg"" preserveAspectRatio=""xMidYMid slice"" focusable=""false"" role=""img"" aria-label=""Placeholder: 140x140""><title>Placeholder</title><rect width=""100%"" height=""100%"" fill=""#777"" /><text x=""50%"" y=""50%"" fill=""#777"" dy="".3em"">140x140</text></svg>
            <h2>Follow</h2>
            <p>Donec sed odio dui. Cras justo odio, dapibus ac facilisis in, egestas eget quam. Vestibulum id ligula porta felis euismod semper. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus.</p>

        </div><!-- /.col-lg-4 -->
    </div><!-- /.row -->


</div><!-- /.container -->

<hr class=""featurette-divider"">
<!--Cards Images-->
<div class=""container"">
    <div class=""row"">
");
#nullable restore
#line 73 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Portfolio\Index.cshtml"
         foreach (var item in Model)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-sm-4\">\n                <div class=\"card\">\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "afffb5a1d9c7b99575000af8c32d2f5c706ddc8813278", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 4058, "~/images/portfolio/", 4058, 19, true);
#nullable restore
#line 78 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Portfolio\Index.cshtml"
AddHtmlAttributeValue("", 4077, item.ImageUrl, 4077, 14, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                    <div class=\"card-body\">\n                        <h5 class=\"card-title\">");
#nullable restore
#line 80 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Portfolio\Index.cshtml"
                                          Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n                        <p class=\"card-text\">");
#nullable restore
#line 81 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Portfolio\Index.cshtml"
                                        Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                        <a href=\"#\" class=\"btn btn-primary\">Go somewhere</a>\n                    </div>\n                    <div class=\"card-footer\">\n                        <small class=\"text-muted\">Last updated 3 mins ago</small>\n");
#nullable restore
#line 86 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Portfolio\Index.cshtml"
                         if (SignInManager.IsSignedIn(User)&& User.IsInRole("Admin"))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <button class=\"btn btn-success btn-sm float-right\" data-toggle=\"modal\" data-target=\"#modal-default \" id=\"clicked\"");
            BeginWriteAttribute("onclick", " onclick=\"", 4785, "\"", 4814, 3);
            WriteAttributeValue("", 4795, "clicked(\'", 4795, 9, true);
#nullable restore
#line 88 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Portfolio\Index.cshtml"
WriteAttributeValue("", 4804, item.Id, 4804, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4812, "\')", 4812, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\n                                <i class=\"fas fa-edit\"></i>\n                            </button>\n");
#nullable restore
#line 91 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Portfolio\Index.cshtml"

                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\n                </div>\n            </div>\n            <br />\n");
#nullable restore
#line 97 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Portfolio\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
</div>


<hr class=""featurette-divider"">


<!--Pricing-->
<section class=""pricing-table"" id=""pricing"">
    <div class=""container"">
        <div class=""block-heading"">
            <h2>Pricing Table</h2>
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc quam urna, dignissim nec auctor in, mattis vitae leo.</p>
        </div>
        <div class=""row justify-content-md-center"">
            <div class=""col-md-5 col-lg-4"">
                <div class=""item"">
                    <div class=""heading"">
                        <h3>BASIC</h3>
                    </div>
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                    <div class=""features"">
                        <h4><span class=""feature"">Full Support</span> : <span class=""value"">No</span></h4>
                        <h4><span class=""feature"">Duration</span> : <span class=""value"">30 Days</span></h4>
                        <h4><span class=""feature"">Storage</span> : <span class=""");
            WriteLiteral(@"value"">10GB</span></h4>
                    </div>
                    <div class=""price"">
                        <h4>$25</h4>
                    </div>
                    <button class=""btn btn-block btn-outline-primary"" type=""submit"">BUY NOW</button>
                </div>
            </div>
            <div class=""col-md-5 col-lg-4"">
                <div class=""item"">
                    <div class=""ribbon"">Best Value</div>
                    <div class=""heading"">
                        <h3>PRO</h3>
                    </div>
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                    <div class=""features"">
                        <h4><span class=""feature"">Full Support</span> : <span class=""value"">Yes</span></h4>
                        <h4><span class=""feature"">Duration</span> : <span class=""value"">60 Days</span></h4>
                        <h4><span class=""feature"">Storage</span> : <span class=""value"">50GB</span></h4>
                    </div>
          ");
            WriteLiteral(@"          <div class=""price"">
                        <h4>$50</h4>
                    </div>
                    <button class=""btn btn-block btn-primary"" type=""submit"">BUY NOW</button>
                </div>
            </div>
            <div class=""col-md-5 col-lg-4"">
                <div class=""item"">
                    <div class=""heading"">
                        <h3>PREMIUM</h3>
                    </div>
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                    <div class=""features"">
                        <h4><span class=""feature"">Full Support</span> : <span class=""value"">Yes</span></h4>
                        <h4><span class=""feature"">Duration</span> : <span class=""value"">120 Days</span></h4>
                        <h4><span class=""feature"">Storage</span> : <span class=""value"">150GB</span></h4>
                    </div>
                    <div class=""price"">
                        <h4>$150</h4>
                    </div>
                    <butt");
            WriteLiteral(@"on class=""btn btn-block btn-outline-primary"" type=""submit"">BUY NOW</button>
                </div>
            </div>
        </div>
    </div>
</section>
<!--End Pricing-->
<!--Modal-->
<div class=""modal fade"" id=""modal-default"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header bg-success"">
                <h4 class=""modal-title align-content-center"">Edite</h4>

            </div>
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "afffb5a1d9c7b99575000af8c32d2f5c706ddc8821204", async() => {
                WriteLiteral("\n                <div class=\"modal-body\">\n\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "afffb5a1d9c7b99575000af8c32d2f5c706ddc8821527", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 180 "C:\Users\HP\Documents\GitHub\Club_Management\MyApps\MyApps\Views\Portfolio\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                    <div style=""width:auto"" id=""cardBodyModal"">

                    </div>

                </div>
                <div class=""modal-footer justify-content-between"">
                    <button type=""button"" class=""btn btn-danger"" data-dismiss=""modal""><i class=""fas fa-times""></i></button>
                    <button type=""submit"" class=""btn btn-success""><i class=""fas fa-save""></i></button>
                </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n        </div>\n        <!-- /.modal-content -->\n    </div>\n    <!-- /.modal-dialog -->\n</div>\n<!-- /.modal-dialog -->\n\n\n\n\n\n\n    \n\n\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script>


        function clicked(id) {
            $(function () {

                var dataa = $(""#cardBodyModal"")
                dataa.html("""")
                var url = ""/Portfolio/GetPortfolio/"" + id

                $.ajax({
                    url: url,
                    type: ""Get"",
                    contentType: ""application/json;charset=utf-8"",
                    dataType: ""json"",
                    success: function (result) {
                      
                        var html = ' <div class=""form-group""> <label class=""control-label"">Titre</label> </div>' +
                            ' <div class=""form-group""> <input type=""text"" name=""Title"" id=""title"" class=""form-control"" placeholder=""Choisir un titre""/></div>' +
                            ' <div class=""form-group""> <label class=""control-label"">Description</label> </div>' +
                            ' <div class=""form-group""> <textarea name=""Description"" class=""form-control"" placeholder=""ecrire un titre"" id=""desc""></textare");
                WriteLiteral(@"a></div>' +
                            ' <div class=""form-group""> <label class=""control-label"">Image Url</label> </div>' +
                            '<div class=""custom-file"">'
                            +
                            '<input type=""hidden"" name=""Id"" value=""' + id + '"" />  <input type=""file"" class=""custom-file-input"" name=""ImageUrl"" id=""customFile"">    <label class=""custom-file-label"" for=""customFile"">Choose file</label> </div>'

                        dataa.append(html)
                        $(""#desc"").val(result.description)
                        $(""#title"").val(result.title)

                    }

                })


            })
        }



    </script>

");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Identity.SignInManager<DataAccessLayer.ApplicationUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Entities.Portfolio.Portfolio>> Html { get; private set; }
    }
}
#pragma warning restore 1591
