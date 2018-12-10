using DluzynaSzkola2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Components
{
    public class AktualnosciArchiwum : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public AktualnosciArchiwum(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var aktualnosciData = _context.Aktualnosci
                 .OrderByDescending(a => a.Dzien)
                .ToList();
            if (aktualnosciData == null)
            {
                var seedEntry = new Aktualnosci
                {
                    Tytul = "Nowy wpis",
                    Tresc = "Wpisz tresc tutaj",
                    Dzien = DateTime.Now
                };
                _context.Aktualnosci.Add(seedEntry);
                _context.SaveChanges();
            }
            return View(aktualnosciData);
        }
    }
}
