using DluzynaSzkola2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Components
{
    public class ZmianaDisplay : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public ZmianaDisplay(ApplicationDbContext context)
        {
            _context = context;
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
            string fileDirectory = Path.Combine(
                      Directory.GetCurrentDirectory(), "wwwroot/uploaded/zm/");
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
