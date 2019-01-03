using System.Collections.Generic;

namespace DluzynaSzkola2.Models
{
    public interface IZajeciaDodatkoweRepository
    {
        IEnumerable<ZajeciaDodatkowe> ZajeciaDodatkowes { get; }
        void SaveZajecia(ZajeciaDodatkowe zajecia);
    }
}
