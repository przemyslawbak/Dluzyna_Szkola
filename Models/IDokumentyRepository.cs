using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public interface IDokumentyRepository
    {
        IEnumerable<Dokumenty> Dokumentys { get; }
        void SaveDokumenty(Dokumenty dokumenty);
    }
}
