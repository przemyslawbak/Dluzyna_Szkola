using System.Collections.Generic;

namespace DluzynaSzkola2.Models
{
    public interface IAktualnosciRepository
    {
        IEnumerable<Aktualnosci> AktualnosciList { get; }
        Aktualnosci DeleteAktualnosci(int id);
        void SaveAktualnosci(Aktualnosci aktualnosci);
    }
}
