using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public interface ISukcesyRepository
    {
        IEnumerable<Sukcesy> Sukcesys { get; }
        Sukcesy DeleteSukces(int id);
        void SaveSukces(Sukcesy grono);
    }
}
