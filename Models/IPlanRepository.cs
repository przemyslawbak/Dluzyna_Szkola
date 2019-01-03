using System.Collections.Generic;

namespace DluzynaSzkola2.Models
{
    public interface IPlanRepository
    {
        IEnumerable<Plan> Plans { get; }
        void SavePlan (Plan plan);
    }
}
