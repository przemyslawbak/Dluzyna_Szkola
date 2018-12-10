using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public interface IHistoriaRepository
    {
        IEnumerable<Historia> Historias { get; }
        void SaveHistoria(Historia historia);
    }
}
