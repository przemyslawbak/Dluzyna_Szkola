using DluzynaSzkola2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DluzynaSzkola2.Controllers
{
    public class GronoPedagogiczneController : Controller
    {
        IGronoPedagogiczneRepository repository;
        public GronoPedagogiczneController(IGronoPedagogiczneRepository repo)
        {
            repository = repo;
        }

        public ActionResult Index() //Index
        {
            var gronoPedagogiczne = repository.GronoPedagogicznes
                .OrderBy(g => g.Nazwisko)
                .ToList();
            return View(gronoPedagogiczne);
        }

        [Authorize(Roles = "Moderatorzy, Administratorzy")]
        // GET: Aktualnosci/Create
        public ViewResult Create()
        {
            var newPerson = new GronoPedagogiczne
            {
                Zdjecie = "**POMIJAMY**",
                Imie = "Tu wpisz imię",
                Nazwisko = "Tu wpisz nazwisko",
                Funkcje = "Tu wpisz funkcje"
            };
            return View("Edit", newPerson);
        }

        [Authorize(Roles = "Moderatorzy, Administratorzy")]
        // GET: Aktualnosci/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            GronoPedagogiczne editedPerson = repository.GronoPedagogicznes
                .FirstOrDefault(g => g.ID == id);
            if (editedPerson == null)
            {
                return NotFound();
            }
            else
            {
                return View(editedPerson);
            }
        }

        [Authorize(Roles = "Moderatorzy, Administratorzy")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GronoPedagogiczne editedPerson)
        {
            if (ModelState.IsValid)
            {
                if (editedPerson == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                repository.SaveGrono(editedPerson);
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Moderatorzy, Administratorzy")]
        // POST: Aktualnosci/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            //repo delete
            repository.DeleteGrono(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
