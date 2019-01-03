using DluzynaSzkola2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DluzynaSzkola2.Components
{
    public class FootKontakt : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public FootKontakt(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var kontaktData = _context.Kontakts.FirstOrDefault();
            if (kontaktData == null)
            {
                var seedEntry = new Kontakt
                {
                    AdresUlica = "Wpisz ulicę i numer",
                    AdresMiastoKod = "Wpisz kod pocztowy i miejscowość",
                    AdresWojewodztwo = "Wpisz wojjewództwo",
                    Email = "Wpisz adres email kontaktowy",
                    Phone = "Wpisz telefon kontaktowy",
                    Fax = "Wpisz numer Fax",
                    LinkGoogleMaps = "Wpisz link do map google"
                };
                _context.Kontakts.Add(seedEntry);
                _context.SaveChanges();
            }
            return View(kontaktData);
        }
    }
}
