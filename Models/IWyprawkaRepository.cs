using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public interface IWyprawkaRepository
    {
        IEnumerable<Wyprawka> Wyprawkas { get; }
        void SaveWyprawka(Wyprawka wyprawka);
    }
}
