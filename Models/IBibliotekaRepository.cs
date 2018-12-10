using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public interface IBibliotekaRepository
    {
        IEnumerable<Biblioteka> Bibliotekas { get; }
        void SaveBiblioteka(Biblioteka biblioteka);
    }
}
