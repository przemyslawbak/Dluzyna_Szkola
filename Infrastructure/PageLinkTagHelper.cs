using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using DluzynaSzkola2.Models.ViewModels;

namespace DluzynaSzkola2.Infrastructure
{
    [HtmlTargetElement("span", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;
        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingInfoViewModel PageModel { get; set; }
        public string PageAction { get; set; }
        public override void Process(TagHelperContext context,
        TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("span");
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                if (i == PageModel.CurrentPage)
                {
                    tag.Attributes["class"] = "tagThisStyle";
                }
                else
                {
                    tag.Attributes["class"] = "tagStyle";
                }
                tag.Attributes["href"] = urlHelper.Action(PageAction, new { myPage = i });
                tag.InnerHtml.Append(i.ToString() + "");
                result.InnerHtml.AppendHtml(tag);
            }
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}

