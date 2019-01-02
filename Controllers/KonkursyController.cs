using DluzynaSzkola2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Security.Application;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Controllers
{
    public class KonkursyController : Controller
    {
        private IKonkursyRepository repository;
        public KonkursyController(IKonkursyRepository repo)
        {
            repository = repo; //repository
        }
        public ActionResult Index()
        {
            Konkursy dataBase = repository.Konkursys.FirstOrDefault();
            if (dataBase == null)
            {
                dataBase = new Konkursy
                {
                    Tresc = "Wpisz tutaj treść."
                };
                repository.SaveKonkursy(dataBase);
            }
            string fileDirectory = Path.Combine(
                      Directory.GetCurrentDirectory(), "wwwroot/uploaded/konk/");
            bool exists = Directory.Exists(fileDirectory);
            if (exists == false) Directory.CreateDirectory(fileDirectory);
            ViewBag.fileList = Directory
                .EnumerateFiles(fileDirectory, "*", SearchOption.AllDirectories)
                .Select(Path.GetFileName);
            ViewBag.fileDirectory = fileDirectory;
            return View(dataBase);
        }

        [Authorize(Roles = "Moderatorzy, Administratorzy")]
        public ActionResult Edit()
        {
            Konkursy dataBase = repository.Konkursys.FirstOrDefault();
            if (dataBase == null)
            {
                dataBase = new Konkursy
                {
                    Tresc = "Wpisz tutaj treść."
                };
                repository.SaveKonkursy(dataBase);
            }
            string fileDirectory = Path.Combine(
                      Directory.GetCurrentDirectory(), "wwwroot/uploaded/konk/");
            ViewBag.fileList = Directory
                .EnumerateFiles(fileDirectory, "*", SearchOption.AllDirectories)
                .Select(Path.GetFileName);
            ViewBag.fileDirectory = fileDirectory;
            return View(dataBase);
        }

        [Authorize(Roles = "Moderatorzy, Administratorzy")]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Konkursy modelReturned, List<IFormFile> files)
        {
            Konkursy dataBase = repository.Konkursys.FirstOrDefault();
            dataBase.Tresc = Sanitizer.GetSafeHtmlFragment(modelReturned.Tresc);
            repository.SaveKonkursy(dataBase);
            if (files != null)
            {
                long size = files.Sum(f => f.Length);
                var filePath = "";
                foreach (var formFile in files)
                {
                    filePath = Path.Combine(
                      Directory.GetCurrentDirectory(), "wwwroot/uploaded/konk/",
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
            return RedirectToAction(nameof(Index));
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
                      Directory.GetCurrentDirectory(), "wwwroot/uploaded/konk/");
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
            Konkursy dataBase = repository.Konkursys.FirstOrDefault();
            return View("Edit", dataBase);
        }
    }
}
