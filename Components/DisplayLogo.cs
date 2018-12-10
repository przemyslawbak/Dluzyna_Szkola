using DluzynaSzkola2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Components
{
    public class DisplayLogo : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public DisplayLogo(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var displayDarkView = _context.ApplicationDisplays.FirstOrDefault();
            if (displayDarkView == null)
            {
                var newDisplay = new ApplicationDisplay
                {
                    DisplayDark = false
                };
                _context.ApplicationDisplays.Add(newDisplay);
                _context.SaveChanges();
                displayDarkView = newDisplay;
            }
            return View(displayDarkView);
        }
    }
}
