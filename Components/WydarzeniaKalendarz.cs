using DluzynaSzkola2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DluzynaSzkola2.Components
{
    public class WydarzeniaKalendarz : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public WydarzeniaKalendarz(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var wydarzeniaData = _context.Wydarzenias
                 .OrderBy(a => a.WhenHappens)
                .ToList();
            if (wydarzeniaData == null)
            {
                var seedEntry = new Wydarzenia
                {
                    Title = "First Entry",
                    Description = "To be changed",
                    WhenHappens = DateTime.Now
                };
                _context.Wydarzenias.Add(seedEntry);
                _context.SaveChanges();
            }
            return View(wydarzeniaData);
        }
    }
}
