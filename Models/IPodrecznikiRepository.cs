using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public interface IPodrecznikiRepository
    {
        IEnumerable<Podreczniki> Podrecznikis { get; }
        void SavePodreczniki(Podreczniki podreczniki);
    }
}
