using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WebLayer.Models;

namespace WebLayer.TagHelpers
{

    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {

        private IUrlHelperFactory urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }
        [ViewContext]
        public ViewContext? ViewContext { get; set; }

        public PageInfo? PageModel { get; set; }

        public string? PageAction { get; set; }

        public string PageClass { get; set; } =string.Empty;
        public string PageClassLink { get; set; } = string.Empty;
        public string PageClassActive { get; set; } = string.Empty;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext != null && PageModel != null)
            {
                IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

                TagBuilder div = new TagBuilder("div");

                for (int i = 1; i <= PageModel.TotalPages; i++)
                {
                    TagBuilder tag = new TagBuilder("a");
                    var url = urlHelper.Action(PageAction, new { page = i });
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassActive : PageClassLink);
                    tag.Attributes["href"] = url;
                    tag.InnerHtml.AppendHtml(i.ToString());
                    div.InnerHtml.AppendHtml(tag);
                  
                }

                output.Content.AppendHtml(div.InnerHtml);
            }
           
        }
    }
}
