﻿using DluzynaSzkola2.Infrastructure;
using DluzynaSzkola2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DluzynaSzkola2.Controllers
{
    public class SukcesyController : Controller
    {
        ISukcesyRepository repository;
        public SukcesyController(ISukcesyRepository repo)
        {
            repository = repo;
        }

        public ActionResult Index() //Index
        {
            var sukcesy = repository.Sukcesys
                .OrderBy(g => g.Tytul)
                .ToList();
            return View(sukcesy);
        }

        [Authorize(Roles = "Moderatorzy, Administratorzy")]
        // GET: /Create
        public ViewResult Create()
        {
            var sukces = new Sukcesy
            {
                Tytul = "Wpisz tytuł",
                Tresc = "Wpisz treść"
            };
            return View("Edit", sukces);
        }

        [Authorize(Roles = "Moderatorzy, Administratorzy")]
        // GET: /Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Sukcesy editedSukces = repository.Sukcesys
                .FirstOrDefault(g => g.ID == id);
            if (editedSukces == null)
            {
                return NotFound();
            }
            else
            {
                return View(editedSukces);
            }
        }

        [Authorize(Roles = "Moderatorzy, Administratorzy")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sukcesy modelReturned)
        {
            Sukcesy dataBase = repository.Sukcesys.FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (modelReturned == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                dataBase.Tytul = modelReturned.Tytul;
                dataBase.Tresc = HtmlUtility.RemoveInvalidHtmlTags(modelReturned.Tresc);
                repository.SaveSukces(dataBase);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(modelReturned);
            }
        }

        [Authorize(Roles = "Moderatorzy, Administratorzy")]
        // POST: /Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            //repo delete
            repository.DeleteSukces(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Aktualnosci/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Sukcesy aktualnosci = repository.Sukcesys
                .FirstOrDefault(m => m.ID == id);
            if (aktualnosci == null)
            {
                return NotFound();
            }
            Sukcesy dataBase = repository.Sukcesys.FirstOrDefault();
            return View("Details", dataBase);
        }
    }
}
