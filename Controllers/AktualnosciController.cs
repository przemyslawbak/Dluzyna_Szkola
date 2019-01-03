using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using DluzynaSzkola2.Models;
using DluzynaSzkola2.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.Security.Application;

namespace DluzynaSzkola2.Controllers
{
    public class AktualnosciController : Controller
    {
        public int PageSize = 4;
        IAktualnosciRepository aktualnosciRepository;
        AktualnosciCreateVM aktualnosciCreateVM = new AktualnosciCreateVM();
        public AktualnosciController (IAktualnosciRepository aktualnosciRepo)
        {
            aktualnosciRepository = aktualnosciRepo;
        }

        public ActionResult Index(int myPage = 1) //Index
        {
            //VM instance
            AktualnosciViewModel aktualnosciVM = new AktualnosciViewModel
            {
                ListOfAktualnosci = aktualnosciRepository.
                AktualnosciList
                .OrderByDescending(a => a.Dzien)
                  .Skip((myPage - 1) * PageSize)
                  .Take(PageSize),
                PagingInfo = new PagingInfoViewModel
                {
                    CurrentPage = myPage,
                    ItemsPerPage = PageSize,
                    TotalItems = aktualnosciRepository.AktualnosciList.Count()
                }
            };
            return View(aktualnosciVM);
        }

        // GET: Aktualnosci/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Aktualnosci aktualnosci = aktualnosciRepository.AktualnosciList
                .FirstOrDefault(m => m.ID == id);
            if (aktualnosci == null)
            {
                return NotFound();
            }
            return View(aktualnosci);
        }

        [Authorize(Roles = "Moderatorzy, Administratorzy")]
        // GET: Aktualnosci/Create
        public IActionResult Create()
        {
            var newAktualnosci = new AktualnosciCreateVM
            {
                Tytul = "Nowy wpis",
                Tresc = "Wpisz tresc tutaj",
                Dzien = DateTime.Now,
                Galeria = "#"
            };
            return View("Edit", newAktualnosci);
        }
        [Authorize(Roles = "Moderatorzy, Administratorzy")]
        // GET: Aktualnosci/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Aktualnosci aktualnosci = aktualnosciRepository.AktualnosciList
                .FirstOrDefault(m => m.ID == id);
            if (aktualnosci == null)
            {
                return NotFound();
            }
            else
            {
                aktualnosciCreateVM.ID = aktualnosci.ID;
                aktualnosciCreateVM.Tytul = aktualnosci.Tytul;
                aktualnosciCreateVM.Tresc = aktualnosci.Tresc;
                aktualnosciCreateVM.Dzien = aktualnosci.Dzien;
                aktualnosciCreateVM.Galeria = aktualnosci.Galeria;
                aktualnosciCreateVM.CurrentImage = aktualnosci.AktualnosciImage;
                aktualnosci.Remove = false;
                return View(aktualnosciCreateVM);
            }
        }
        [Authorize(Roles = "Moderatorzy, Administratorzy")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AktualnosciCreateVM aktualnosci, byte[] picture)
        {
            if (ModelState.IsValid)
            {
                if (aktualnosci == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                long? aktualnosciID = aktualnosci.ID;
                Aktualnosci targetAktualnosci;
                if (aktualnosciID == 0)
                {
                    targetAktualnosci = new Aktualnosci();
                }
                else
                {
                    targetAktualnosci = aktualnosciRepository.AktualnosciList
                        .FirstOrDefault(m => m.ID == aktualnosci.ID);
                }
                if (aktualnosci.AktualnosciImage != null)
                {
                    if (aktualnosci.Remove != true)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await aktualnosci.AktualnosciImage.CopyToAsync(memoryStream);
                            targetAktualnosci.AktualnosciImage = memoryStream.ToArray();
                        }
                    }
                    else
                    {
                        targetAktualnosci.AktualnosciImage = null;
                    }
                }
                else
                {
                    if (aktualnosci.Remove == true) targetAktualnosci.AktualnosciImage = null;
                }
                targetAktualnosci.Dzien = aktualnosci.Dzien;
                targetAktualnosci.Tresc = Sanitizer.GetSafeHtmlFragment(aktualnosci.Tresc);
                targetAktualnosci.Tytul = aktualnosci.Tytul;
                targetAktualnosci.Galeria = aktualnosci.Galeria;
                aktualnosciRepository.SaveAktualnosci(targetAktualnosci);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(aktualnosci);
            }
        }

        [Authorize(Roles = "Moderatorzy, Administratorzy")]
        // POST: Aktualnosci/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            //repo delete
            aktualnosciRepository.DeleteAktualnosci(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
