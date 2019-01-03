using System.Collections.Generic;

namespace DluzynaSzkola2.Models
{
    public interface IZmianaPlanuRepository
    {
        IEnumerable<ZmianaPlanu> ZmianaPlanus { get; }
        void SaveZmianaPlanu(ZmianaPlanu zmianaPlanu);
    }
}
