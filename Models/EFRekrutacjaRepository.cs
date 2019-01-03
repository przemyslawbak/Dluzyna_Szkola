using System.Collections.Generic;
using System.Linq;

namespace DluzynaSzkola2.Models
{
    public class EFRekrutacjaRepository : IRekrutacjaRepository
    {
        private ApplicationDbContext _context;
        public EFRekrutacjaRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        public IEnumerable<Rekrutacja> Rekrutacjas => _context.Rekrutacjas.ToList();
        public void SaveRekrutacja(Rekrutacja input)
        {
            Rekrutacja change = new Rekrutacja();
            if (input.ID == 0)
            {
                _context.Rekrutacjas.Add(change);
            }
            else
            {
                change = _context.Rekrutacjas.FirstOrDefault(a => a.ID == input.ID);
            }
            change.Tresc = input.Tresc;
            _context.SaveChanges();
        }
    }
}
