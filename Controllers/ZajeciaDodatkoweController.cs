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
    public class ZajeciaDodatkoweController : Controller
    {
        private IZajeciaDodatkoweRepository repository;
        public ZajeciaDodatkoweController(IZajeciaDodatkoweRepository repo)
        {
            repository = repo; //repository
        }
        public ActionResult Index()
        {
            ZajeciaDodatkowe dataBase = repository.ZajeciaDodatkowes.FirstOrDefault();
            if (dataBase == null)
            {
                dataBase = new ZajeciaDodatkowe
                {
                    Tresc = "Wpisz tutaj treść."
                };
                repository.SaveZajecia(dataBase);
            }
            string fileDirectory = Path.Combine(
                      Directory.GetCurrentDirectory(), "wwwroot/uploaded/zaj/");
            bool exists = Directory.Exists(fileDirectory);
            if (exists == false) Directory.CreateDirectory(fileDirectory);
            ViewBag.fileList = Directory
                .EnumerateFiles(fileDirectory, "*", SearchOption.AllDirectories)
                .Select(Path.GetFileName);
            ViewBag.fileDirectory = fileDirectory;
            return View(dataBase);
        }

        [Authorize(Roles = "Moderatorzy")]
        public ActionResult Edit()
        {
            ZajeciaDodatkowe dataBase = repository.ZajeciaDodatkowes.FirstOrDefault();
            if (dataBase == null)
            {
                dataBase = new ZajeciaDodatkowe
                {
                    Tresc = "Wpisz tutaj treść."
                };
                repository.SaveZajecia(dataBase);
            }
            string fileDirectory = Path.Combine(
                      Directory.GetCurrentDirectory(), "wwwroot/uploaded/zaj/");
            ViewBag.fileList = Directory
                .EnumerateFiles(fileDirectory, "*", SearchOption.AllDirectories)
                .Select(Path.GetFileName);
            ViewBag.fileDirectory = fileDirectory;
            return View(dataBase);
        }

        [Authorize(Roles = "Moderatorzy")]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ZajeciaDodatkowe modelReturned, List<IFormFile> files)
        {
            ZajeciaDodatkowe dataBase = repository.ZajeciaDodatkowes.FirstOrDefault();
            dataBase.Tresc = modelReturned.Tresc;
            repository.SaveZajecia(dataBase);
            if (files != null)
            {
                long size = files.Sum(f => f.Length);
                var filePath = "";
                foreach (var formFile in files)
                {
                    filePath = Path.Combine(
                      Directory.GetCurrentDirectory(), "wwwroot/uploaded/zaj/",
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
        [Authorize(Roles = "Moderatorzy")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFile(string file)
        {
            string fileDirectory = Path.Combine(
                      Directory.GetCurrentDirectory(), "wwwroot/uploaded/zaj/");
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
            ZajeciaDodatkowe dataBase = repository.ZajeciaDodatkowes.FirstOrDefault();
            return View("Edit", dataBase);
        }
    }
}
