using System.Collections.Generic;
using System.Linq;

namespace DluzynaSzkola2.Models
{
    public class EFZajeciaDodatkoweRepository : IZajeciaDodatkoweRepository
    {
        private ApplicationDbContext _context;
        public EFZajeciaDodatkoweRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        public IEnumerable<ZajeciaDodatkowe> ZajeciaDodatkowes => _context.ZajeciaDodatkowes.ToList();
        public void SaveZajecia(ZajeciaDodatkowe input)
        {
            ZajeciaDodatkowe change = new ZajeciaDodatkowe();
            if (input.ID == 0)
            {
                _context.ZajeciaDodatkowes.Add(change);
            }
            else
            {
                change = _context.ZajeciaDodatkowes.FirstOrDefault(a => a.ID == input.ID);
            }
            change.Tresc = input.Tresc;
            _context.SaveChanges();
        }
    }
}
