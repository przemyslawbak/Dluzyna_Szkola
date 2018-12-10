using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public class EFPlanRepository : IPlanRepository
    {
        private ApplicationDbContext _context;
        public EFPlanRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        public IEnumerable<Plan> Plans => _context.Plans.ToList();
        public void SavePlan(Plan input)
        {
            Plan change = new Plan();
            if (input.ID == 0)
            {
                _context.Plans.Add(change);
            }
            else
            {
                change = _context.Plans.FirstOrDefault(a => a.ID == input.ID);
            }
            change.Tresc = input.Tresc;
            _context.SaveChanges();
        }
    }
}
