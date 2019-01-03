using System.Collections.Generic;

namespace DluzynaSzkola2.Models
{
    public interface IPodrecznikiRepository
    {
        IEnumerable<Podreczniki> Podrecznikis { get; }
        void SavePodreczniki(Podreczniki podreczniki);
    }
}
