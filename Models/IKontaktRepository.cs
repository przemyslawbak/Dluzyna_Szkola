using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public interface IKontaktRepository
    {
        IEnumerable<Kontakt> Kontakts { get; }
        void SaveKontakt(Kontakt kontakt);
    }
}
