#pragma checksum "C:\MyStuff\MyScripts\netCourse\BookStore\BookStoreDesk\Views\Home\Trending.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "12a4b2989764fa83eaac54c176c50dcc1373b239"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Trending), @"mvc.1.0.view", @"/Views/Home/Trending.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Trending.cshtml", typeof(AspNetCore.Views_Home_Trending))]
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
#line 1 "C:\MyStuff\MyScripts\netCourse\BookStore\BookStoreDesk\Views\_ViewImports.cshtml"
using BookStoreDesk;

#line default
#line hidden
#line 2 "C:\MyStuff\MyScripts\netCourse\BookStore\BookStoreDesk\Views\_ViewImports.cshtml"
using BookStoreDesk.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12a4b2989764fa83eaac54c176c50dcc1373b239", @"/Views/Home/Trending.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4e5650015b5f00b082ab6468140a9e61a662a54", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Trending : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BookStoreDesk.Models.TrendingViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\MyStuff\MyScripts\netCourse\BookStore\BookStoreDesk\Views\Home\Trending.cshtml"
  
    ViewData["Title"] = "BookStore";

#line default
#line hidden
            BeginContext(92, 605, true);
            WriteLiteral(@"
<div class=""container-fluid"">
    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""row"">
                <div class=""col-md-6"">
                    <div class=""list-group"">
                        <a href=""#"" class=""list-group-item list-group-item-action active"">Trending Books</a>
                        <div class=""list-group-item"">
                            <h4 class=""list-group-item-heading"">
                                Order by Qualification review votes.
                            </h4>
                            <ol class=""list-group-item-text"">
");
            EndContext();
#line 18 "C:\MyStuff\MyScripts\netCourse\BookStore\BookStoreDesk\Views\Home\Trending.cshtml"
                                 foreach (var item in Model.TrendingBooks)
                                {

#line default
#line hidden
            BeginContext(808, 92, true);
            WriteLiteral("                                <li class=\"list-item\">\r\n                                    ");
            EndContext();
            BeginContext(901, 143, false);
#line 21 "C:\MyStuff\MyScripts\netCourse\BookStore\BookStoreDesk\Views\Home\Trending.cshtml"
                               Write(Html.ActionLink(item.Name, "Details","Books", routeValues: new { Id = item.Id },
                                        htmlAttributes: null));

#line default
#line hidden
            EndContext();
            BeginContext(1044, 48, true);
            WriteLiteral(" <span class=\"badge badge-secondary badge-pill\">");
            EndContext();
            BeginContext(1093, 45, false);
#line 22 "C:\MyStuff\MyScripts\netCourse\BookStore\BookStoreDesk\Views\Home\Trending.cshtml"
                                                                                                        Write(Html.DisplayFor(modelItem => item.ReviewsSum));

#line default
#line hidden
            EndContext();
            BeginContext(1138, 48, true);
            WriteLiteral("</span>\r\n                                </li>\r\n");
            EndContext();
#line 24 "C:\MyStuff\MyScripts\netCourse\BookStore\BookStoreDesk\Views\Home\Trending.cshtml"
                                }

#line default
#line hidden
            BeginContext(1221, 582, true);
            WriteLiteral(@"                            </ol>
                        </div>
                    </div>
                </div>
                <div class=""col-md-6"">
                    <div class=""list-group"">
                        <a href=""#"" class=""list-group-item list-group-item-action active"">Newest Books</a>
                        <div class=""list-group-item"">
                            <h4 class=""list-group-item-heading"">
                                Order by Newest.
                            </h4>
                            <ul class=""list-group-item-text"">
");
            EndContext();
#line 37 "C:\MyStuff\MyScripts\netCourse\BookStore\BookStoreDesk\Views\Home\Trending.cshtml"
                                 foreach (var item in Model.NewestBooks)
                                {

#line default
#line hidden
            BeginContext(1912, 100, true);
            WriteLiteral("                                    <li class=\"list-item\">\r\n                                        ");
            EndContext();
            BeginContext(2013, 147, false);
#line 40 "C:\MyStuff\MyScripts\netCourse\BookStore\BookStoreDesk\Views\Home\Trending.cshtml"
                                   Write(Html.ActionLink(item.Name, "Details","Books", routeValues: new { Id = item.Id },
                                            htmlAttributes: null));

#line default
#line hidden
            EndContext();
            BeginContext(2160, 43, true);
            WriteLiteral(" <span class=\"badge badge-info badge-pill\">");
            EndContext();
            BeginContext(2204, 44, false);
#line 41 "C:\MyStuff\MyScripts\netCourse\BookStore\BookStoreDesk\Views\Home\Trending.cshtml"
                                                                                                       Write(Html.DisplayFor(modelItem => item.Published));

#line default
#line hidden
            EndContext();
            BeginContext(2248, 52, true);
            WriteLiteral("</span>\r\n                                    </li>\r\n");
            EndContext();
#line 43 "C:\MyStuff\MyScripts\netCourse\BookStore\BookStoreDesk\Views\Home\Trending.cshtml"
                                }

#line default
#line hidden
            BeginContext(2335, 175, true);
            WriteLiteral("                            </ul>\r\n                        </div>\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BookStoreDesk.Models.TrendingViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
