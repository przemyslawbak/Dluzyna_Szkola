using System.Collections.Generic;

namespace DluzynaSzkola2.Models
{
    public interface IAutobusRepository
    {
        IEnumerable<Autobus> Autobuses { get; }
        void SaveAutobusy(Autobus autobusy);
    }
}
