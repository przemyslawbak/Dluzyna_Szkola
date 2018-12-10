using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public class EFApplicationDisplay : IApplicationDisplay
    {
        private ApplicationDbContext _context;
        public EFApplicationDisplay(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        public IEnumerable<ApplicationDisplay> ApplicationDisplays => _context.ApplicationDisplays.ToList();
        public void SaveApplicationDisplay(ApplicationDisplay input)
        {
            ApplicationDisplay change = new ApplicationDisplay();
            if (input.ID == 0)
            {
                _context.ApplicationDisplays.Add(change);
            }
            else
            {
                change = _context.ApplicationDisplays.FirstOrDefault(a => a.ID == input.ID);
            }
            change.DisplayDark = input.DisplayDark;
            _context.SaveChanges();
        }
    }
}
