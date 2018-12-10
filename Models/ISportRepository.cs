using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public interface ISportRepository
    {
        IEnumerable<Sport> Sports { get; }
        void SaveSport(Sport sport);
    }
}

