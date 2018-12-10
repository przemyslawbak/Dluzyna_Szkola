using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public interface ISolectwoRepository
    {
        IEnumerable<Solectwo> Solectwos { get; }
        void SaveSolectwo(Solectwo solectwo);
    }
}
