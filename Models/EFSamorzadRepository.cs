using System.Collections.Generic;
using System.Linq;

namespace DluzynaSzkola2.Models
{
    public class EFSamorzadRepository : ISamorzadRepository
    {
        private ApplicationDbContext _context;
        public EFSamorzadRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        public IEnumerable<Samorzad> Samorzads => _context.Samorzads.ToList();
        public void SaveSamorzad(Samorzad input)
        {
            Samorzad change = new Samorzad();
            if (input.ID == 0)
            {
                _context.Samorzads.Add(change);
            }
            else
            {
                change = _context.Samorzads.FirstOrDefault(a => a.ID == input.ID);
            }
            change.Tresc = input.Tresc;
            _context.SaveChanges();
        }
    }
}
