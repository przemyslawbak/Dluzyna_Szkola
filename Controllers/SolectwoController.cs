﻿using DluzynaSzkola2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Controllers
{
    public class SolectwoController : Controller
    {
        private ISolectwoRepository repository;
        public SolectwoController(ISolectwoRepository repo)
        {
            repository = repo; //repository
        }
        public ActionResult Index()
        {
            Solectwo dataBase = repository.Solectwos.FirstOrDefault();
            if (dataBase == null)
            {
                dataBase = new Solectwo
                {
                    Tresc = "Wpisz tutaj treść."
                };
                repository.SaveSolectwo(dataBase);
            }
            return View(dataBase);
        }

        [Authorize(Roles = "Moderatorzy")]
        public ActionResult Edit()
        {
            Solectwo dataBase = repository.Solectwos.FirstOrDefault();
            if (dataBase == null)
            {
                dataBase = new Solectwo
                {
                    Tresc = "Wpisz tutaj treść."
                };
                repository.SaveSolectwo(dataBase);
            }
            return View(dataBase);
        }

        [Authorize(Roles = "Moderatorzy")]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Solectwo modelReturned)
        {
            Solectwo dataBase = repository.Solectwos.FirstOrDefault();
            dataBase.Tresc = modelReturned.Tresc;
            repository.SaveSolectwo(dataBase);
            return RedirectToAction(nameof(Index));
        }
    }
}
