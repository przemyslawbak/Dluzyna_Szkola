using Microsoft.AspNetCore.Mvc;
using System.Linq;
using DluzynaSzkola2.Models;
using Microsoft.AspNetCore.Authorization;

namespace DluzynaSzkola2.Controllers
{
    public class KontaktController : Controller
    {
        private IKontaktRepository repository;
        public KontaktController(IKontaktRepository repo)
        {
            repository = repo; //repository
        }
        public ActionResult Index()
        {
            Kontakt dataBase = repository.Kontakts.FirstOrDefault();
            if (dataBase == null)
            {
                dataBase = new Kontakt
                {
                    AdresUlica = "Wpisz ulicę i numer",
                    AdresMiastoKod = "Wpisz kod pocztowy i miejscowość",
                    AdresWojewodztwo = "Wpisz wojjewództwo",
                    Email = "Wpisz adres email kontaktowy",
                    Phone = "Wpisz telefon kontaktowy",
                    Fax = "Wpisz numer Fax",
                    LinkGoogleMaps = "Wpisz link do map google"
                };
                repository.SaveKontakt(dataBase);
            }
            return View(dataBase);
        }

        [Authorize(Roles = "Moderatorzy, Administratorzy")]
        public ActionResult Edit()
        {
            Kontakt dataBase = repository.Kontakts.FirstOrDefault();
            if (dataBase == null)
            {
                dataBase = new Kontakt
                {
                    AdresUlica = "Wpisz ulicę i numer",
                    AdresMiastoKod = "Wpisz kod pocztowy i miejscowość",
                    AdresWojewodztwo = "Wpisz wojjewództwo",
                    Email = "Wpisz adres email kontaktowy",
                    Phone = "Wpisz telefon kontaktowy",
                    Fax = "Wpisz numer Fax",
                    LinkGoogleMaps = "Wpisz link do map google"
                };
                repository.SaveKontakt(dataBase);
            }
            return View(dataBase);
        }

        [Authorize(Roles = "Moderatorzy, Administratorzy")]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Kontakt modelReturned)
        {
            if (ModelState.IsValid)
            {
                Kontakt dataBase = repository.Kontakts.FirstOrDefault();
                dataBase.AdresUlica = modelReturned.AdresUlica;
                dataBase.AdresMiastoKod = modelReturned.AdresMiastoKod;
                dataBase.AdresWojewodztwo = modelReturned.AdresWojewodztwo;
                dataBase.Phone = modelReturned.Phone;
                dataBase.Email = modelReturned.Email;
                dataBase.Fax = modelReturned.Fax;
                dataBase.LinkGoogleMaps = modelReturned.LinkGoogleMaps;
                repository.SaveKontakt(dataBase);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(modelReturned);
            }
        }
    }
}
