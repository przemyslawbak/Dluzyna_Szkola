using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public class EFGronoPedagogiczneRepository : IGronoPedagogiczneRepository
    {
        private ApplicationDbContext _context;
        public EFGronoPedagogiczneRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        public IEnumerable<GronoPedagogiczne> GronoPedagogicznes => _context.GronoPedagogicznes.ToList();

        public GronoPedagogiczne DeleteGrono(int id)
        {
            GronoPedagogiczne grono = _context.GronoPedagogicznes
                .SingleOrDefault(i => i.ID == id);
            if (grono != null)
            {
                _context.GronoPedagogicznes.Remove(grono);
                _context.SaveChanges();
            }
            return null;
        }

        public void SaveGrono(GronoPedagogiczne grono)
        {
            GronoPedagogiczne gronoChange = new GronoPedagogiczne();
            if (grono.ID == 0)
            {
                _context.GronoPedagogicznes.Add(gronoChange);
            }
            else
            {
                gronoChange = _context.GronoPedagogicznes.FirstOrDefault(a => a.ID == grono.ID);
            }
            gronoChange.Zdjecie = grono.Zdjecie;
            gronoChange.Imie = grono.Imie;
            gronoChange.Nazwisko = grono.Nazwisko;
            gronoChange.Funkcje = grono.Funkcje;

            _context.SaveChanges();
        }
    }
}
