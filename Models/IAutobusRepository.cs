using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public interface IAutobusRepository
    {
        IEnumerable<Autobus> Autobuses { get; }
        void SaveAutobusy(Autobus autobusy);
    }
}
