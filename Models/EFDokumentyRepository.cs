using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public class EFDokumentyRepository: IDokumentyRepository
    {
        private ApplicationDbContext _context;
        public EFDokumentyRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        public IEnumerable<Dokumenty> Dokumentys => _context.Dokumentys.ToList();
        public void SaveDokumenty(Dokumenty input)
        {
            Dokumenty change = new Dokumenty();
            if (input.ID == 0)
            {
                _context.Dokumentys.Add(change);
            }
            else
            {
                change = _context.Dokumentys.FirstOrDefault(a => a.ID == input.ID);
            }
            change.Tresc = input.Tresc;
            _context.SaveChanges();
        }
    }
}
