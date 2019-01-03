using DluzynaSzkola2.Infrastructure;
using DluzynaSzkola2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace DluzynaSzkola2.Components
{
    public class ZmianaDisplay : ViewComponent
    {
        Backslasher bck = new Backslasher();
        private readonly string fileDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploaded", "zm");
        private readonly ApplicationDbContext _context;
        public ZmianaDisplay(ApplicationDbContext context)
        {
            _context = context;
            fileDirectory = bck.PathAddBackslash(fileDirectory);
        }
        public IViewComponentResult Invoke()
        {
            var zmianaPlanuData = _context.ZmianaPlanus.FirstOrDefault();
            if (zmianaPlanuData == null)
            {
                var seedEntry = new ZmianaPlanu
                {
                    Info = "Zmień treść",
                    DzienRozpoczęcia = DateTime.Now,
                    DzienZakonczenia = DateTime.Now.AddDays(7)
                };
                _context.ZmianaPlanus.Add(seedEntry);
                _context.SaveChanges();
            }
            bool exists = Directory.Exists(fileDirectory);
            if (exists == false) Directory.CreateDirectory(fileDirectory);
            ViewBag.fileList = Directory
                .EnumerateFiles(fileDirectory, "*", SearchOption.AllDirectories)
                .Select(Path.GetFileName);
            ViewBag.fileDirectory = fileDirectory;
            return View(zmianaPlanuData);
        }
    }
}
