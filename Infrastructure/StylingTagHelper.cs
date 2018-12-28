using DluzynaSzkola2.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Infrastructure
{
    [HtmlTargetElement(Attributes = CustomBorderColor)]
    [HtmlTargetElement(Attributes = CustomTextColor)]
    [HtmlTargetElement(Attributes = CustomBackground)]
    public class StylingTagHelper : TagHelper
    {
        ColorConverts konwerter = new ColorConverts();
        private const string CustomBorderColor = "custombordercolor";
        private const string CustomTextColor = "customtextcolor";
        private const string CustomBackground = "custombackground";
        [HtmlAttributeName(CustomBackground)]
        public string TheBackground { get; set; } //własność helpera
        [HtmlAttributeName(CustomTextColor)]
        public string TheTextColor { get; set; } //własność helpera
        [HtmlAttributeName(CustomBorderColor)]
        public string TheBorder { get; set; } //własność helpera
        private IApplicationDisplay repository;

        public StylingTagHelper(IApplicationDisplay repo)
        {
            repository = repo;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string addedColor = "";
            string addedBackground = "";
            string addedBorder = "";
            string changes = "";
            var colors = repository.ApplicationDisplays.FirstOrDefault(); //context
            switch (TheBackground)
            {
                case "glownynaglowektlo":
                    addedBackground = "background-color:" + colors.GlownyNaglowekTlo + "; "; //nowy kolor
                    break;
                case "stronatlo":
                    addedBackground = "background-color:" + colors.StronaTlo + "; "; //nowy kolor
                    break;
                case "przyciskikolor":
                    addedBackground = "background-color:" + colors.PrzyciskiKolor +"; "; //nowy kolor
                    break;
                case "tresctlo":
                    addedBackground = "background-color:" + colors.TrescTlo + "; "; //nowy kolor
                    break;
                case "naglowkikolor":
                    addedBackground = "background-color:" + colors.NaglowkiTlo + "; "; //nowy kolor
                    break;
                    //kolory menu rozwijanego
                case "p1":
                    addedBackground = "background-color:" + konwerter.Konwertuj(colors.GlownyNaglowekTlo, 0.1) + "; "; //nowy kolor
                    break;
                case "p2":
                    addedBackground = "background-color:" + konwerter.Konwertuj(colors.GlownyNaglowekTlo, 0.2) + "; "; //nowy kolor
                    break;
                case "p3":
                    addedBackground = "background-color:" + konwerter.Konwertuj(colors.GlownyNaglowekTlo, 0.3) + "; "; //nowy kolor
                    break;
                case "p4":
                    addedBackground = "background-color:" + konwerter.Konwertuj(colors.GlownyNaglowekTlo, 0.4) + "; "; //nowy kolor
                    break;
            }
            switch (TheTextColor)
            {
                case "strefaadminakolor":
                    addedColor = "color:" + colors.StrefaAdminaKolor + "; "; //nowy kolor
                    break;
                case "tresckolor":
                    addedColor = "color:" + colors.TrescKolor + "; "; //nowy kolor
                    break;
                case "tekstnaglowkow":
                    addedColor = "color:" + colors.TrescTlo + "; "; //nowy kolor
                    break;
            }
            switch (TheBorder)
            {
                case "tresctlo":
                    addedBorder = "border-color:" + colors.TrescTlo + "; "; //nowy kolor
                    break;
                case "glownynaglowektlo":
                    addedBorder = "border-color:" + colors.GlownyNaglowekTlo + "; "; //nowy kolor
                    break;
            }
            changes = addedBackground + addedBorder + addedColor;
            if (!output.Attributes.ContainsName("style"))
            {
                output.Attributes.SetAttribute("style", changes);
            }
            else
            {
                var currentAttribute = output.Attributes.FirstOrDefault(attribute => attribute.Name == "style"); //get value of 'style'
                string newAttributeValue = $"{currentAttribute.Value.ToString() + "; " + changes}"; //combine style values
                output.Attributes.Remove(currentAttribute); //remove old attribute
                output.Attributes.SetAttribute("style", newAttributeValue); //add merged attribute values
            }
        }
    }
}
