using System.Collections.Generic;

namespace DluzynaSzkola2.Models
{
    public interface IKonkursyRepository
    {
        IEnumerable<Konkursy> Konkursys { get; }
        void SaveKonkursy (Konkursy konkursy);
    }
}
