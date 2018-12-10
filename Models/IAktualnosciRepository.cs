using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public interface IAktualnosciRepository
    {
        IEnumerable<Aktualnosci> AktualnosciList { get; }
        Aktualnosci DeleteAktualnosci(int id);
        void SaveAktualnosci(Aktualnosci aktualnosci);
    }
}
