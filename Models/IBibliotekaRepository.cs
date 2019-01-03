using System.Collections.Generic;

namespace DluzynaSzkola2.Models
{
    public interface IBibliotekaRepository
    {
        IEnumerable<Biblioteka> Bibliotekas { get; }
        void SaveBiblioteka(Biblioteka biblioteka);
    }
}
