using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public interface IGronoPedagogiczneRepository
    {
        IEnumerable<GronoPedagogiczne> GronoPedagogicznes { get; }
        GronoPedagogiczne DeleteGrono(int id);
        void SaveGrono(GronoPedagogiczne grono);
    }
}
