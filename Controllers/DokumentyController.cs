using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using DluzynaSzkola2.Models;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Security.Application;
using DluzynaSzkola2.Infrastructure;

namespace DluzynaSzkola2.Controllers
{
    public class DokumentyController : Controller
    {
        Backslasher bck = new Backslasher();
        private readonly string fileDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploaded", "dok");
        private IDokumentyRepository repository;
        public DokumentyController(IDokumentyRepository repo)
        {
            repository = repo; //repository
            fileDirectory = bck.PathAddBackslash(fileDirectory);
        }
        public ActionResult Index()
        {
            Dokumenty dataBase = repository.Dokumentys.FirstOrDefault();
            if (dataBase == null)
            {
                dataBase = new Dokumenty
                {
                    Tresc = "Wpisz tutaj treść."
                };
                repository.SaveDokumenty(dataBase);
            }
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
            Dokumenty dataBase = repository.Dokumentys.FirstOrDefault();
            if (dataBase == null)
            {
                dataBase = new Dokumenty
                {
                    Tresc = "Wpisz tutaj treść."
                };
                repository.SaveDokumenty(dataBase);
            }
            ViewBag.fileList = Directory
                .EnumerateFiles(fileDirectory, "*", SearchOption.AllDirectories)
                .Select(Path.GetFileName);
            ViewBag.fileDirectory = fileDirectory;
            return View(dataBase);
        }

        [Authorize(Roles = "Moderatorzy, Administratorzy")]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Dokumenty modelReturned, List<IFormFile> files)
        {
            Dokumenty dataBase = repository.Dokumentys.FirstOrDefault();
            dataBase.Tresc = Sanitizer.GetSafeHtmlFragment(modelReturned.Tresc);
            repository.SaveDokumenty(dataBase);
            if (files != null)
            {
                long size = files.Sum(f => f.Length);
                var filePath = "";
                foreach (var formFile in files)
                {
                    filePath = Path.Combine(fileDirectory, formFile.FileName);
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
            bool match = false;
            string[] files = Directory.GetFiles(fileDirectory, "*", SearchOption.AllDirectories);
            foreach (string item in files)
            {
                if (item == file) match = true;
            }
            if (match)
            {
                if (System.IO.File.Exists(file) && Path.GetFullPath(file).StartsWith(fileDirectory, StringComparison.OrdinalIgnoreCase))
                {
                    var fileBytes = System.IO.File.ReadAllBytes(file);
                    var response = new FileContentResult(fileBytes, "application/octet-stream")
                    {
                        FileDownloadName = file.Split('\\').Last()
                    };
                    return response;
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }
        [Authorize(Roles = "Moderatorzy, Administratorzy")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFile(string file)
        {
            ViewBag.fileList = Directory
                .EnumerateFiles(fileDirectory, "*", SearchOption.AllDirectories)
                .Select(Path.GetFileName);
            ViewBag.fileDirectory = fileDirectory;
            var fileName = "";
            fileName = file;
            var fullPath = Path.Combine(fileDirectory, file);

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
                ViewBag.deleteSuccess = "true";
            }
            Dokumenty dataBase = repository.Dokumentys.FirstOrDefault();
            return View("Edit", dataBase);
        }
    }
}
