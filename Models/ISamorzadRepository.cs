using System.Collections.Generic;

namespace DluzynaSzkola2.Models
{
    public interface ISamorzadRepository
    {
        IEnumerable<Samorzad> Samorzads { get; }
        void SaveSamorzad (Samorzad samorzad);
    }
}
