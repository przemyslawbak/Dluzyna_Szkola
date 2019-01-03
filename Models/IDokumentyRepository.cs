using System.Collections.Generic;

namespace DluzynaSzkola2.Models
{
    public interface IDokumentyRepository
    {
        IEnumerable<Dokumenty> Dokumentys { get; }
        void SaveDokumenty(Dokumenty dokumenty);
    }
}
