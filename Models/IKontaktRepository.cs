using System.Collections.Generic;

namespace DluzynaSzkola2.Models
{
    public interface IKontaktRepository
    {
        IEnumerable<Kontakt> Kontakts { get; }
        void SaveKontakt(Kontakt kontakt);
    }
}
