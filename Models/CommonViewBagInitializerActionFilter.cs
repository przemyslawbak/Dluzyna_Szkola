using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DluzynaSzkola2.Controllers;

namespace DluzynaSzkola2.Models
{
    //color info for JS plugins
    public class CommonViewBagInitializerActionFilter : ActionFilterAttribute
    {
        private readonly IApplicationDisplay repository;
        public CommonViewBagInitializerActionFilter(IApplicationDisplay repo)
        {
            repository = repo;
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {

            var colors = repository.ApplicationDisplays.FirstOrDefault();
            if (colors == null)
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
