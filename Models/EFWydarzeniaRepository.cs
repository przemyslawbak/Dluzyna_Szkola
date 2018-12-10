using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public class EFWydarzeniaRepository : IWydarzeniaRepository
    {
        private ApplicationDbContext _context;
        public EFWydarzeniaRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        public IEnumerable<Wydarzenia> Wydarzenias => _context.Wydarzenias.ToList();
        public Wydarzenia DeleteWydarzenia(int id)
        {
            Wydarzenia wydarzenia = _context.Wydarzenias
                .SingleOrDefault(i => i.ID == id);
            if (wydarzenia != null)
            {
                _context.Wydarzenias.Remove(wydarzenia);
                _context.SaveChanges();
            }
            return null;
        }

        public void SaveWydarzenia(Wydarzenia wydarzenia)
        {
            Wydarzenia wydarzeniaChange = new Wydarzenia();
            if (wydarzenia.ID == 0)
            {
                _context.Wydarzenias.Add(wydarzeniaChange);
            }
            else
            {
                wydarzeniaChange = _context.Wydarzenias.FirstOrDefault(a => a.ID == wydarzenia.ID);
            }
            wydarzeniaChange.Title = wydarzenia.Title;
            wydarzeniaChange.Description = wydarzenia.Description;
            wydarzeniaChange.WhenHappens = wydarzenia.WhenHappens;
            _context.SaveChanges();
        }
    }
}
