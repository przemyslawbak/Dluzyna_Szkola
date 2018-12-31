using DluzynaSzkola2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Controllers
{
    public class WydarzeniaController : Controller
    {
        IWydarzeniaRepository repository;
        public WydarzeniaController(IWydarzeniaRepository repo)
        {
            repository = repo;
        }

        public ActionResult Index() //Index
        {
            var wydarzenia = repository.Wydarzenias
                .OrderByDescending(w => w.WhenHappens)
                .ToList();
            return View(wydarzenia);
        }

        [Authorize(Roles = "Moderatorzy, Administratorzy")]
        // GET: Aktualnosci/Create
        public ViewResult Create()
        {
            var newWydarzenie = new Wydarzenia
            {
                Title = "Wpisz tytuł",
                Description = "Wpisz krótki opis wydarzenia",
                WhenHappens = DateTime.Now
            };
            return View("Edit", newWydarzenie);
        }

        [Authorize(Roles = "Moderatorzy, Administratorzy")]
        // GET: /Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Wydarzenia editedWydarzenia = repository.Wydarzenias
                .FirstOrDefault(g => g.ID == id);
            if (editedWydarzenia == null)
            {
                return NotFound();
            }
            else
            {
                return View(editedWydarzenia);
            }
        }

        [Authorize(Roles = "Moderatorzy, Administratorzy")]
        // POST: /Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Wydarzenia editedWydarzenia)
        {
            if (ModelState.IsValid)
            {
                if (editedWydarzenia == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                repository.SaveWydarzenia(editedWydarzenia);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(editedWydarzenia);
            }
        }

        [Authorize(Roles = "Moderatorzy, Administratorzy")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            //repo delete
            repository.DeleteWydarzenia(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
