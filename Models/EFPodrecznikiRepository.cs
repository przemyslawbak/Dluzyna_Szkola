using System.Collections.Generic;
using System.Linq;

namespace DluzynaSzkola2.Models
{
    public class EFPodrecznikiRepository : IPodrecznikiRepository
    {
        private ApplicationDbContext _context;
        public EFPodrecznikiRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        public IEnumerable<Podreczniki> Podrecznikis => _context.Podrecznikis.ToList();
        public void SavePodreczniki(Podreczniki input)
        {
            Podreczniki change = new Podreczniki();
            if (input.ID == 0)
            {
                _context.Podrecznikis.Add(change);
            }
            else
            {
                change = _context.Podrecznikis.FirstOrDefault(a => a.ID == input.ID);
            }
            change.Tresc = input.Tresc;
            _context.SaveChanges();
        }
    }
}
