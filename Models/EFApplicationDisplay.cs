using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public class EFApplicationDisplay : IApplicationDisplay
    {
        private ApplicationDbContext _context;
        public EFApplicationDisplay(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        public IEnumerable<ApplicationDisplay> ApplicationDisplays => _context.ApplicationDisplays.ToList();
        public void SaveApplicationDisplay(ApplicationDisplay input)
        {
            ApplicationDisplay change = new ApplicationDisplay();
            if (input.ID == 0)
            {
                change.NaglowkiTlo = "brown";
                change.PrzyciskiKolor = "orange";
                change.StrefaAdminaKolor = "green";
                change.StronaTlo = "white";
                change.TrescKolor = "black";
                change.TrescTlo = "white";
                _context.ApplicationDisplays.Add(change);
            }
            else
            {
                change = _context.ApplicationDisplays.FirstOrDefault(a => a.ID == input.ID);
            }
            change.GlownyNaglowekTlo = input.GlownyNaglowekTlo;
            change.NaglowkiTlo = input.NaglowkiTlo;
            change.PrzyciskiKolor = input.PrzyciskiKolor;
            change.StrefaAdminaKolor = input.StrefaAdminaKolor;
            change.StronaTlo = input.StronaTlo;
            change.TrescKolor = input.TrescKolor;
            change.TrescTlo = input.TrescTlo;
            change.DisplayDark = input.DisplayDark;
            _context.SaveChanges();
        }
    }
}
