using System.Collections.Generic;

namespace DluzynaSzkola2.Models
{
    public interface IRadaRodzicowRepository
    {
        IEnumerable<RadaRodzicow> RadaRodzicows { get; }
        void SaveRadaRodzicow(RadaRodzicow rada);
    }
}
