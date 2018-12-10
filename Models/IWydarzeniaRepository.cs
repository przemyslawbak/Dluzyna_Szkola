using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public interface IWydarzeniaRepository
    {
        IEnumerable<Wydarzenia> Wydarzenias { get; }
        Wydarzenia DeleteWydarzenia(int id);
        void SaveWydarzenia(Wydarzenia wydarzenia);
    }
}
