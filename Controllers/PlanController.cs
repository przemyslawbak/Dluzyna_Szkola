﻿using DluzynaSzkola2.Infrastructure;
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
    public class PlanController : Controller
    {
        Backslasher bck = new Backslasher();
        private readonly string fileDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploaded", "plan");
        private IPlanRepository repository;
        public PlanController(IPlanRepository repo)
        {
            repository = repo; //repository
            fileDirectory = bck.PathAddBackslash(fileDirectory);
        }
        public ActionResult Index()
        {
            Plan dataBase = repository.Plans.FirstOrDefault();
            if (dataBase == null)
            {
                dataBase = new Plan
                {
                    Tresc = "Wpisz tutaj treść."
                };
                repository.SavePlan(dataBase);
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
            Plan dataBase = repository.Plans.FirstOrDefault();
            if (dataBase == null)
            {
                dataBase = new Plan
                {
                    Tresc = "Wpisz tutaj treść."
                };
                repository.SavePlan(dataBase);
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
        public async Task<IActionResult> Edit(Plan modelReturned, List<IFormFile> files)
        {
            Plan dataBase = repository.Plans.FirstOrDefault();
            dataBase.Tresc = HtmlUtility.RemoveInvalidHtmlTags(modelReturned.Tresc);
            repository.SavePlan(dataBase);
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
            Plan dataBase = repository.Plans.FirstOrDefault();
            return View("Edit", dataBase);
        }
    }
}
