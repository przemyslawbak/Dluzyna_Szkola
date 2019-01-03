using System.Collections.Generic;
using System.Linq;

namespace DluzynaSzkola2.Models
{
    public class EFSukcesyRepository : ISukcesyRepository
    {
        private ApplicationDbContext _context;
        public EFSukcesyRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        public IEnumerable<Sukcesy> Sukcesys => _context.Sukcesys.ToList();
        public Sukcesy DeleteSukces(int id)
        {
            Sukcesy sukces = _context.Sukcesys
                .SingleOrDefault(i => i.ID == id);
            if (sukces != null)
            {
                _context.Sukcesys.Remove(sukces);
                _context.SaveChanges();
            }
            return null;
        }

        public void SaveSukces(Sukcesy sukces)
        {
            Sukcesy sukcesChange = new Sukcesy();
            if (sukces.ID == 0)
            {
                _context.Sukcesys.Add(sukcesChange);
            }
            else
            {
                sukcesChange = _context.Sukcesys.FirstOrDefault(a => a.ID == sukces.ID);
            }
            sukcesChange.Tytul = sukces.Tytul;
            sukcesChange.Tresc = sukces.Tresc;
            _context.SaveChanges();
        }
    }
}
