using System.Collections.Generic;
using System.Linq;

namespace DluzynaSzkola2.Models
{
    public class EFBibliotekaRepository : IBibliotekaRepository
    {
        private ApplicationDbContext _context;
        public EFBibliotekaRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        public IEnumerable<Biblioteka> Bibliotekas => _context.Bibliotekas.ToList();
        public void SaveBiblioteka(Biblioteka input)
        {
            Biblioteka change = new Biblioteka();
            if (input.ID == 0)
            {
                _context.Bibliotekas.Add(change);
            }
            else
            {
                change = _context.Bibliotekas.FirstOrDefault(a => a.ID == input.ID);
            }
            change.Tresc = input.Tresc;
            _context.SaveChanges();
        }
    }
}
