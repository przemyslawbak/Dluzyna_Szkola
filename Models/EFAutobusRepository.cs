using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public class EFAutobusRepository : IAutobusRepository
    {
        private ApplicationDbContext _context;
        public EFAutobusRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        public IEnumerable<Autobus> Autobuses => _context.Autobuses.ToList();
        public void SaveAutobusy(Autobus input)
        {
            Autobus change = new Autobus();
            if (input.ID == 0)
            {
                _context.Autobuses.Add(change);
            }
            else
            {
                change = _context.Autobuses.FirstOrDefault(a => a.ID == input.ID);
            }
            change.Tresc = input.Tresc;
            _context.SaveChanges();
        }
    }
}
