#pragma checksum "C:\Users\Misa\Source\Repos\2019p2prg-adventure-rpg-game-hubnerova-antos\RPG-game\Pages\Pages.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dfb44013fc2d30fc206b6a4bc2123e84f2de684b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(RPG_game.Pages.Pages_Pages), @"mvc.1.0.razor-page", @"/Pages/Pages.cshtml")]
namespace RPG_game.Pages
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
#line 1 "C:\Users\Misa\Source\Repos\2019p2prg-adventure-rpg-game-hubnerova-antos\RPG-game\Pages\_ViewImports.cshtml"
using RPG_game;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Misa\Source\Repos\2019p2prg-adventure-rpg-game-hubnerova-antos\RPG-game\Pages\Pages.cshtml"
using RPG_game.Model;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dfb44013fc2d30fc206b6a4bc2123e84f2de684b", @"/Pages/Pages.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c233633631f270d28bc4dcfc167e84d741ff6a78", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Pages : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Pages", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\Misa\Source\Repos\2019p2prg-adventure-rpg-game-hubnerova-antos\RPG-game\Pages\Pages.cshtml"
  
    ViewData["Title"] = "Pages";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dfb44013fc2d30fc206b6a4bc2123e84f2de684b4297", async() => {
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>Pages</title>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dfb44013fc2d30fc206b6a4bc2123e84f2de684b5356", async() => {
                WriteLiteral("\r\n");
                DefineSection("Scripts", async() => {
                    WriteLiteral("\r\n");
#nullable restore
#line 17 "C:\Users\Misa\Source\Repos\2019p2prg-adventure-rpg-game-hubnerova-antos\RPG-game\Pages\Pages.cshtml"
          await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
                    WriteLiteral("    ");
                }
                );
                WriteLiteral("    <div class=\"text-center\">\r\n        <h1 class=\"display-4\">");
#nullable restore
#line 20 "C:\Users\Misa\Source\Repos\2019p2prg-adventure-rpg-game-hubnerova-antos\RPG-game\Pages\Pages.cshtml"
                         Write(Model.Location.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h1>\r\n        <p>");
#nullable restore
#line 21 "C:\Users\Misa\Source\Repos\2019p2prg-adventure-rpg-game-hubnerova-antos\RPG-game\Pages\Pages.cshtml"
      Write(Model.Location.Description);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n        <div class=\"btn-group-vertical\">\r\n");
#nullable restore
#line 23 "C:\Users\Misa\Source\Repos\2019p2prg-adventure-rpg-game-hubnerova-antos\RPG-game\Pages\Pages.cshtml"
             foreach (var item in Model.Location.Paths)
            {
                if (item.IsLocked == true)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <a class=\"btn btn-secondary disabled\">");
#nullable restore
#line 27 "C:\Users\Misa\Source\Repos\2019p2prg-adventure-rpg-game-hubnerova-antos\RPG-game\Pages\Pages.cshtml"
                                                     Write(item.PathDescription);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a>\r\n");
#nullable restore
#line 28 "C:\Users\Misa\Source\Repos\2019p2prg-adventure-rpg-game-hubnerova-antos\RPG-game\Pages\Pages.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dfb44013fc2d30fc206b6a4bc2123e84f2de684b7764", async() => {
#nullable restore
#line 31 "C:\Users\Misa\Source\Repos\2019p2prg-adventure-rpg-game-hubnerova-antos\RPG-game\Pages\Pages.cshtml"
                                                                                                  Write(item.PathDescription);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-to", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 31 "C:\Users\Misa\Source\Repos\2019p2prg-adventure-rpg-game-hubnerova-antos\RPG-game\Pages\Pages.cshtml"
                                           WriteLiteral(item.NextLocationId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["to"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-to", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["to"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 32 "C:\Users\Misa\Source\Repos\2019p2prg-adventure-rpg-game-hubnerova-antos\RPG-game\Pages\Pages.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RPG_game.Pages.PagesModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RPG_game.Pages.PagesModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RPG_game.Pages.PagesModel>)PageContext?.ViewData;
        public RPG_game.Pages.PagesModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
