using System.Collections.Generic;

namespace DluzynaSzkola2.Models
{
    public interface IWydarzeniaRepository
    {
        IEnumerable<Wydarzenia> Wydarzenias { get; }
        Wydarzenia DeleteWydarzenia(int id);
        void SaveWydarzenia(Wydarzenia wydarzenia);
    }
}
