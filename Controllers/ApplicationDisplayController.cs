using DluzynaSzkola2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DluzynaSzkola2.Controllers
{
    [Authorize(Roles = "Administratorzy")]
    public class ApplicationDisplayController : Controller
    {
        private IApplicationDisplay repository;
        public ApplicationDisplayController(IApplicationDisplay repo)
        {
            repository = repo;
        }
        public ActionResult Edit()
        {
            var displayView = repository.ApplicationDisplays.FirstOrDefault();
            if (displayView == null)
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
                displayView = newDisplay;
            }
            return View(displayView);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApplicationDisplay modelReturned)
        {
            ApplicationDisplay dataBase = repository.ApplicationDisplays.FirstOrDefault();
            dataBase.GlownyNaglowekTlo = modelReturned.GlownyNaglowekTlo;
            dataBase.NaglowkiTlo = modelReturned.NaglowkiTlo;
            dataBase.PrzyciskiKolor = modelReturned.PrzyciskiKolor;
            dataBase.StrefaAdminaKolor = modelReturned.StrefaAdminaKolor;
            dataBase.StronaTlo = modelReturned.StronaTlo;
            dataBase.TrescKolor = modelReturned.TrescKolor;
            dataBase.TrescTlo = modelReturned.TrescTlo;
            dataBase.DisplayDark = modelReturned.DisplayDark;
            repository.SaveApplicationDisplay(dataBase);
            return RedirectToAction(nameof(Edit));
        }
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}
