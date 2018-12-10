using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public class EFKonkursyRepository : IKonkursyRepository
    {
        private ApplicationDbContext _context;
        public EFKonkursyRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        public IEnumerable<Konkursy> Konkursys => _context.Konkursys.ToList();
        public void SaveKonkursy(Konkursy input)
        {
            Konkursy change = new Konkursy();
            if (input.ID == 0)
            {
                _context.Konkursys.Add(change);
            }
            else
            {
                change = _context.Konkursys.FirstOrDefault(a => a.ID == input.ID);
            }
            change.Tresc = input.Tresc;
            _context.SaveChanges();
        }
    }
}
