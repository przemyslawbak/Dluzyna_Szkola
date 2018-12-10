using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public class EFKontaktRepository : IKontaktRepository
    {
        private ApplicationDbContext _context;
        public EFKontaktRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        public IEnumerable<Kontakt> Kontakts => _context.Kontakts.ToList();
        public void SaveKontakt(Kontakt input)
        {
            Kontakt change = new Kontakt();
            if (input.ID == 0)
            {
                _context.Kontakts.Add(change);
            }
            else
            {
                change = _context.Kontakts.FirstOrDefault(a => a.ID == input.ID);
            }
            change.AdresMiastoKod = input.AdresMiastoKod;
            change.AdresUlica = input.AdresUlica;
            change.AdresWojewodztwo = input.AdresWojewodztwo;
            change.Email = input.Email;
            change.Phone = input.Phone;
            change.Fax = input.Fax;
            if (input.LinkGoogleMaps == null)
            {
                change.LinkGoogleMaps = "#";
            }
            else
            {
                change.LinkGoogleMaps = input.LinkGoogleMaps;
            }
            _context.SaveChanges();
        }
    }
}
