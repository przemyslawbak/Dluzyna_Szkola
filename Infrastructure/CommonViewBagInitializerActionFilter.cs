using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace DluzynaSzkola2.Models
{
    //globalne info o kolorach, wysyłane przez ViewBag, zarejestrowane w Startup.cs
    public class CommonViewBagInitializerActionFilter : ActionFilterAttribute
    {

        private readonly IApplicationDisplay repository;
        public CommonViewBagInitializerActionFilter(IApplicationDisplay repo)
        {
            repository = repo;
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            ApplicationDisplay colors = new ApplicationDisplay();

            ApplicationDisplay colorsDB = repository.ApplicationDisplays.FirstOrDefault();
            if (colorsDB == null)
            {
                var newDisplay = new ApplicationDisplay
                {
                    NaglowkiTlo = "brown",
                    PrzyciskiKolor = "orange",
                    StrefaAdminaKolor = "green",
                    StronaTlo = "white",
                    TrescKolor = "black",
                    TrescTlo = "white",
                    DisplayDark = false
                };
                repository.SaveApplicationDisplay(newDisplay);
                colors = newDisplay;
            }
            if (colorsDB.DisplayDark) //jeśli żałoba
            {
                colors.GlownyNaglowekTlo = "#000000";
                colors.NaglowkiTlo = "#333332";
                colors.PrzyciskiKolor = "#60605F";
                colors.StrefaAdminaKolor = "#000000";
                colors.StronaTlo = "#E0DCDC";
                colors.TrescKolor = "#000000";
                colors.TrescTlo = "#FFFFFF";
            }
            else
            {
                colors = colorsDB;
            }
            ((Controller)context.Controller).ViewBag.GlownyNaglowekTlo = colors.GlownyNaglowekTlo;
            ((Controller)context.Controller).ViewBag.StronaTlo = colors.StronaTlo;
            ((Controller)context.Controller).ViewBag.PrzyciskiKolor = colors.PrzyciskiKolor;
            ((Controller)context.Controller).ViewBag.TrescTlo = colors.TrescTlo;
            ((Controller)context.Controller).ViewBag.NaglowkiTlo = colors.NaglowkiTlo;
            ((Controller)context.Controller).ViewBag.TrescKolor = colors.TrescKolor;
            ((Controller)context.Controller).ViewBag.StrefaAdminaKolor = colors.StrefaAdminaKolor;
        }
    }
}
