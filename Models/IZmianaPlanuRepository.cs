using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public interface IZmianaPlanuRepository
    {
        IEnumerable<ZmianaPlanu> ZmianaPlanus { get; }
        void SaveZmianaPlanu(ZmianaPlanu zmianaPlanu);
    }
}
