using System.Collections.Generic;
using System.Linq;

namespace DluzynaSzkola2.Models
{
    public class EFZmianaPlanuRepository : IZmianaPlanuRepository
    {
        private ApplicationDbContext _context;
        public EFZmianaPlanuRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        public IEnumerable<ZmianaPlanu> ZmianaPlanus => _context.ZmianaPlanus.ToList();
        public void SaveZmianaPlanu(ZmianaPlanu input)
        {
            ZmianaPlanu change = new ZmianaPlanu();
            if (input.ID == 0)
            {
                _context.ZmianaPlanus.Add(change);
            }
            else
            {
                change = _context.ZmianaPlanus.FirstOrDefault(a => a.ID == input.ID);
            }
            if (input.Info == null)
            {
                change.Info = "#";
            }
            else
            {
                change.Info = input.Info;
            }
            change.DzienRozpoczęcia = input.DzienRozpoczęcia;
            change.DzienZakonczenia = input.DzienZakonczenia;
            _context.SaveChanges();
        }
    }
}
