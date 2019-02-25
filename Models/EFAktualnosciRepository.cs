using System.Collections.Generic;
using System.Linq;

namespace DluzynaSzkola2.Models
{
    public class EFAktualnosciRepository : IAktualnosciRepository
    {
        double sample = 1.0;
        private ApplicationDbContext _context;
        public EFAktualnosciRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        public IEnumerable<Aktualnosci> AktualnosciList => _context.Aktualnosci.ToList();

        public Aktualnosci DeleteAktualnosci(int id)
        {
            Aktualnosci aktualnosci = _context.Aktualnosci
                .SingleOrDefault(i => i.ID == id);
            if (aktualnosci != null)
            {
                _context.Aktualnosci.Remove(aktualnosci);
                _context.SaveChanges();
            }
            return null;
        }

        public void SaveAktualnosci (Aktualnosci aktualnosci)
        {
            Aktualnosci aktualnosciChange = new Aktualnosci();
            if (aktualnosci.ID == 0)
            {
                _context.Aktualnosci.Add(aktualnosciChange);
            }
            else
            {
                aktualnosciChange = _context.Aktualnosci.FirstOrDefault(a => a.ID == aktualnosci.ID);
            }
            aktualnosciChange.Tytul = aktualnosci.Tytul;
            aktualnosciChange.Tresc = aktualnosci.Tresc;
            aktualnosciChange.Dzien = aktualnosci.Dzien;
            if (aktualnosci.Galeria == null)
            {
                aktualnosciChange.Galeria = "#";
            }
            else
            {
                aktualnosciChange.Galeria = aktualnosci.Galeria;
            }
            aktualnosciChange.AktualnosciImage = aktualnosci.AktualnosciImage;
            _context.SaveChanges();
        }
    }
}
