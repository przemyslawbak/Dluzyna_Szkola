using System.Collections.Generic;

namespace DluzynaSzkola2.Models
{
    public interface ISolectwoRepository
    {
        IEnumerable<Solectwo> Solectwos { get; }
        void SaveSolectwo(Solectwo solectwo);
    }
}
