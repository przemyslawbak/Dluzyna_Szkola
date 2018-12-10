using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public class EFSolectwoRepository : ISolectwoRepository
    {
        private ApplicationDbContext _context;
        public EFSolectwoRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        public IEnumerable<Solectwo> Solectwos => _context.Solectwos.ToList();
        public void SaveSolectwo(Solectwo input)
        {
            Solectwo change = new Solectwo();
            if (input.ID == 0)
            {
                _context.Solectwos.Add(change);
            }
            else
            {
                change = _context.Solectwos.FirstOrDefault(a => a.ID == input.ID);
            }
            change.Tresc = input.Tresc;
            _context.SaveChanges();
        }
    }
}
