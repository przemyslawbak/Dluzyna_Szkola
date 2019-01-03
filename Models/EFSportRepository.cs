using System.Collections.Generic;
using System.Linq;

namespace DluzynaSzkola2.Models
{
    public class EFSportRepository : ISportRepository
    {
        private ApplicationDbContext _context;
        public EFSportRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        public IEnumerable<Sport> Sports => _context.Sports.ToList();
        public void SaveSport(Sport input)
        {
            Sport change = new Sport();
            if (input.ID == 0)
            {
                _context.Sports.Add(change);
            }
            else
            {
                change = _context.Sports.FirstOrDefault(a => a.ID == input.ID);
            }
            change.Tresc = input.Tresc;
            _context.SaveChanges();
        }
    }
}
