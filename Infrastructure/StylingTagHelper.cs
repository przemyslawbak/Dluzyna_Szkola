using DluzynaSzkola2.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Infrastructure
{
    [HtmlTargetElement(Attributes = CustomTextColor)]
    [HtmlTargetElement(Attributes = CustomBackground)]
    public class StylingTagHelper : TagHelper
    {
        private const string CustomTextColor = "customtextcolor";
        private const string CustomBackground = "custombackground";
        [HtmlAttributeName(CustomBackground)]
        public string TheBackground { get; set; } //helpers property
        [HtmlAttributeName(CustomTextColor)]
        public string TheTextColor { get; set; } //helpers property
        private IApplicationDisplay repository;

        public StylingTagHelper(IApplicationDisplay repo)
        {
            repository = repo;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var backgroundStyle = "";
            var colors = repository.ApplicationDisplays.FirstOrDefault(); //context
            switch (TheBackground)
            {
                case "glownynaglowektlo":
                    backgroundStyle = "background-color:" + colors.GlownyNaglowekTlo; //new color
                    break;
                case "stronatlo":
                    backgroundStyle = "background-color:" + colors.StronaTlo; //new color
                    break;
                case "przyciskikolor":
                    backgroundStyle = "background-color:" + colors.PrzyciskiKolor; //new color
                    break;
                case "tresctlo":
                    backgroundStyle = "background-color:" + colors.TrescTlo; //new color
                    break;
                case "naglowkikolor":
                    backgroundStyle = "background-color:" + colors.NaglowkiTlo; //new color
                    break;
            }
            switch (TheTextColor)
            {
                case "strefaadminakolor":
                    backgroundStyle = "color:" + colors.StrefaAdminaKolor; //new color
                    break;
                case "tresckolor":
                    backgroundStyle = "color:" + colors.TrescKolor; //new color
                    break;
                case "tekstnaglowkow":
                    backgroundStyle = "color:" + colors.TrescTlo; //new color
                    break;
            }
            if (!output.Attributes.ContainsName("style"))
            {
                output.Attributes.SetAttribute("style", backgroundStyle);
            }
            else
            {
                var currentAttribute = output.Attributes.FirstOrDefault(attribute => attribute.Name == "style"); //get value of 'style'
                string newAttributeValue = $"{currentAttribute.Value.ToString() + "; " + backgroundStyle}"; //combine style values
                output.Attributes.Remove(currentAttribute); //remove old attribute
                output.Attributes.SetAttribute("style", newAttributeValue); //add merged attribute values
            }
        }
    }
}
