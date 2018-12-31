using DluzynaSzkola2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Controllers
{
    public class ZmianaPlanuController : Controller
    {
        private IZmianaPlanuRepository repository;
        public ZmianaPlanuController(IZmianaPlanuRepository repo)
        {
            repository = repo; //repository
        }
        [Authorize(Roles = "Moderatorzy, Administratorzy")]
        public ActionResult Edit()
        {
            ZmianaPlanu dataBase = repository.ZmianaPlanus.FirstOrDefault();
            if (dataBase == null)
            {
                dataBase = new ZmianaPlanu
                {
                    Info = "Pobierz plik",
                    DzienRozpoczęcia = DateTime.Now,
                    DzienZakonczenia = DateTime.Now.AddDays(7)
                };
                repository.SaveZmianaPlanu(dataBase);
            }
            string fileDirectory = Path.Combine(
                      Directory.GetCurrentDirectory(), "wwwroot/uploaded/zm/");
            ViewBag.fileList = Directory
                .EnumerateFiles(fileDirectory, "*", SearchOption.AllDirectories)
                .Select(Path.GetFileName);
            ViewBag.fileDirectory = fileDirectory;
            return View(dataBase);
        }

        [Authorize(Roles = "Moderatorzy, Administratorzy")]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ZmianaPlanu modelReturned, List<IFormFile> files)
        {
            ZmianaPlanu dataBase = repository.ZmianaPlanus.FirstOrDefault();
            dataBase.Info = modelReturned.Info;
            dataBase.DzienRozpoczęcia = modelReturned.DzienRozpoczęcia;
            dataBase.DzienZakonczenia = modelReturned.DzienZakonczenia;
            repository.SaveZmianaPlanu(dataBase);
            if (files != null)
            {
                long size = files.Sum(f => f.Length);
                var filePath = "";
                foreach (var formFile in files)
                {
                    filePath = Path.Combine(
                      Directory.GetCurrentDirectory(), "wwwroot/uploaded/zm/",
                      formFile.FileName);
                    if (formFile.Length > 0)
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }
                }
            }
            return RedirectToAction("Index", "Aktualnosci");
        }
        public ActionResult Download(string file)
        {
            if (!System.IO.File.Exists(file))
            {
                return NotFound();
            }

            var fileBytes = System.IO.File.ReadAllBytes(file);
            var response = new FileContentResult(fileBytes, "application/octet-stream")
            {
                FileDownloadName = file.Split('/').Last()
            };
            return response;
        }
        [Authorize(Roles = "Moderatorzy, Administratorzy")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFile(string file)
        {
            string fileDirectory = Path.Combine(
                      Directory.GetCurrentDirectory(), "wwwroot/uploaded/zm/");
            ViewBag.fileList = Directory
                .EnumerateFiles(fileDirectory, "*", SearchOption.AllDirectories)
                .Select(Path.GetFileName);
            ViewBag.fileDirectory = fileDirectory;
            var fileName = "";
            fileName = file;
            var fullPath = fileDirectory + file;

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
                ViewBag.deleteSuccess = "true";
            }
            ZmianaPlanu dataBase = repository.ZmianaPlanus.FirstOrDefault();
            return View("Edit", dataBase);
        }
    }
}
