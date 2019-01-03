using System.Collections.Generic;

namespace DluzynaSzkola2.Models
{
    public interface IWyprawkaRepository
    {
        IEnumerable<Wyprawka> Wyprawkas { get; }
        void SaveWyprawka(Wyprawka wyprawka);
    }
}
