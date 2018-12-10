using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public interface IRadaRodzicowRepository
    {
        IEnumerable<RadaRodzicow> RadaRodzicows { get; }
        void SaveRadaRodzicow(RadaRodzicow rada);
    }
}
