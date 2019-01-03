using System.Collections.Generic;
using System.Linq;

namespace DluzynaSzkola2.Models
{
    public class EFWyprawkaRepository : IWyprawkaRepository
    {
        private ApplicationDbContext _context;
        public EFWyprawkaRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        public IEnumerable<Wyprawka> Wyprawkas => _context.Wyprawkas.ToList();
        public void SaveWyprawka(Wyprawka input)
        {
            Wyprawka change = new Wyprawka();
            if (input.ID == 0)
            {
                _context.Wyprawkas.Add(change);
            }
            else
            {
                change = _context.Wyprawkas.FirstOrDefault(a => a.ID == input.ID);
            }
            change.Tresc = input.Tresc;
            _context.SaveChanges();
        }
    }
}
