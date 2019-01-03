using System.Collections.Generic;

namespace DluzynaSzkola2.Models
{
    public interface ISportRepository
    {
        IEnumerable<Sport> Sports { get; }
        void SaveSport(Sport sport);
    }
}

