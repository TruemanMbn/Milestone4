#pragma checksum "C:\Users\Work\Desktop\onlineShop_Skete\Views\Shared\_ShoppingBusket.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "639fd8b28705a9ecfce69decd0a46e3dff6e1517"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ShoppingBusket), @"mvc.1.0.view", @"/Views/Shared/_ShoppingBusket.cshtml")]
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
#line 1 "C:\Users\Work\Desktop\onlineShop_Skete\Views\_ViewImports.cshtml"
using onlineShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Work\Desktop\onlineShop_Skete\Views\_ViewImports.cshtml"
using onlineShop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"639fd8b28705a9ecfce69decd0a46e3dff6e1517", @"/Views/Shared/_ShoppingBusket.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"deeed74128b1d97d20ba6dcdf6e5d7f9d92dd6ac", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__ShoppingBusket : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<ul class=\"nav navbar-nav navbar-right\">\r\n\t<li>\r\n\t\t<i class=\"fas fa-shopping-cart\">");
#nullable restore
#line 3 "C:\Users\Work\Desktop\onlineShop_Skete\Views\Shared\_ShoppingBusket.cshtml"
                                   Write(Html.ActionLink("(0)","ShoppingCart","Store", new {id ="cartItem"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n\t\t<i class=\"fas fa-heart fa-xl\" style=\"margin-right:100px; color:darkred\">");
#nullable restore
#line 4 "C:\Users\Work\Desktop\onlineShop_Skete\Views\Shared\_ShoppingBusket.cshtml"
                                                                           Write(Html.ActionLink("(0)", "WishList","Store", new {id="wishListItem"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n\t</li>\r\n</ul>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
