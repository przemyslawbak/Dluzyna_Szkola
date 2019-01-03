using System.Collections.Generic;

namespace DluzynaSzkola2.Models
{
    public interface IHistoriaRepository
    {
        IEnumerable<Historia> Historias { get; }
        void SaveHistoria(Historia historia);
    }
}
