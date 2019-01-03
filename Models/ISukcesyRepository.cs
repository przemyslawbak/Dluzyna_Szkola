using System.Collections.Generic;

namespace DluzynaSzkola2.Models
{
    public interface ISukcesyRepository
    {
        IEnumerable<Sukcesy> Sukcesys { get; }
        Sukcesy DeleteSukces(int id);
        void SaveSukces(Sukcesy grono);
    }
}
