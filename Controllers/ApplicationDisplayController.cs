using DluzynaSzkola2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

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
            var displayDarkView = repository.ApplicationDisplays.FirstOrDefault();
            if (displayDarkView == null)
            {
                var newDisplay = new ApplicationDisplay
                {
                    DisplayDark = false
                };
                repository.SaveApplicationDisplay(newDisplay);
                displayDarkView = newDisplay;
            }
            return View(displayDarkView);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApplicationDisplay modelReturned)
        {
            ApplicationDisplay dataBase = repository.ApplicationDisplays.FirstOrDefault();
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
