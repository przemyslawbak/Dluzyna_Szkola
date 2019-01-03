using System.Collections.Generic;
using System.Linq;

namespace DluzynaSzkola2.Models
{
    public class EFRadaRodzicowRepository : IRadaRodzicowRepository
    {
        private ApplicationDbContext _context;
        public EFRadaRodzicowRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        public IEnumerable<RadaRodzicow> RadaRodzicows => _context.RadaRodzicows.ToList();
        public void SaveRadaRodzicow(RadaRodzicow input)
        {
            RadaRodzicow change = new RadaRodzicow();
            if (input.ID == 0)
            {
                _context.RadaRodzicows.Add(change);
            }
            else
            {
                change = _context.RadaRodzicows.FirstOrDefault(a => a.ID == input.ID);
            }
            change.Tresc = input.Tresc;
            _context.SaveChanges();
        }
    }
}
