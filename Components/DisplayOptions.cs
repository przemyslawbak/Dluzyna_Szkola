using DluzynaSzkola2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Components
{
    public class DisplayOptions : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public DisplayOptions(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var displaySettings = _context.ApplicationDisplays.FirstOrDefault();
            if (displaySettings == null)
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
                _context.ApplicationDisplays.Add(newDisplay);
                _context.SaveChanges();
                displaySettings = newDisplay;
            }
            return View(displaySettings);
        }
    }
}
