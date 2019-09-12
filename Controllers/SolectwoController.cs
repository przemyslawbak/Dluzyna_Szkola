using DluzynaSzkola2.Infrastructure;
using DluzynaSzkola2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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

        [Authorize(Roles = "Moderatorzy, Administratorzy")]
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

        [Authorize(Roles = "Moderatorzy, Administratorzy")]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Solectwo modelReturned)
        {
            Solectwo dataBase = repository.Solectwos.FirstOrDefault();
            dataBase.Tresc = HtmlUtility.RemoveInvalidHtmlTags(modelReturned.Tresc);
            repository.SaveSolectwo(dataBase);
            return RedirectToAction(nameof(Index));
        }
    }
}
