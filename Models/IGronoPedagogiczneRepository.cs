using System.Collections.Generic;

namespace DluzynaSzkola2.Models
{
    public interface IGronoPedagogiczneRepository
    {
        IEnumerable<GronoPedagogiczne> GronoPedagogicznes { get; }
        GronoPedagogiczne DeleteGrono(int id);
        void SaveGrono(GronoPedagogiczne grono);
    }
}
