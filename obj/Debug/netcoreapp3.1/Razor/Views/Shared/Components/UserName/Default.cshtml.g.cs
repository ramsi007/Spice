#pragma checksum "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Views\Shared\Components\UserName\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "66d11e5bd8c43174aa96f6f76e6a9f6f063fb98d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_UserName_Default), @"mvc.1.0.view", @"/Views/Shared/Components/UserName/Default.cshtml")]
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
#line 1 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Views\_ViewImports.cshtml"
using Spice;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Views\_ViewImports.cshtml"
using Spice.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Views\_ViewImports.cshtml"
using Spice.Utility;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Views\_ViewImports.cshtml"
using Spice.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66d11e5bd8c43174aa96f6f76e6a9f6f063fb98d", @"/Views/Shared/Components/UserName/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b0781166ce410b3fbc1db563259a6c866e71b405", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_UserName_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ApplicationUser>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("Bonjour!  ");
#nullable restore
#line 2 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.Net MVC\Spice-Project\Spice\Views\Shared\Components\UserName\Default.cshtml"
     Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" &nbsp; &nbsp;<i class=\"fas fa-user\"></i>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ApplicationUser> Html { get; private set; }
    }
}
#pragma warning restore 1591