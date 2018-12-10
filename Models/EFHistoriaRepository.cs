using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public class EFHistoriaRepository : IHistoriaRepository
    {
        private ApplicationDbContext _context;
        public EFHistoriaRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        public IEnumerable<Historia> Historias => _context.Historias.ToList();
        public void SaveHistoria(Historia input)
        {
            Historia change = new Historia();
            if (input.ID == 0)
            {
                _context.Historias.Add(change);
            }
            else
            {
                change = _context.Historias.FirstOrDefault(a => a.ID == input.ID);
            }
            change.Tresc = input.Tresc;
            _context.SaveChanges();
        }
    }
}
