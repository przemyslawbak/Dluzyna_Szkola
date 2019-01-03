using System.Collections.Generic;

namespace DluzynaSzkola2.Models
{
    public interface IRekrutacjaRepository
    {
        IEnumerable<Rekrutacja> Rekrutacjas { get; }
        void SaveRekrutacja (Rekrutacja rekrutacja);
    }
}
