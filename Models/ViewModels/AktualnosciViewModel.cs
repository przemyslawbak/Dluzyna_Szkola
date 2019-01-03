using System.Collections.Generic;

namespace DluzynaSzkola2.Models.ViewModels
{
    public class AktualnosciViewModel
    {
        public IEnumerable<Aktualnosci> ListOfAktualnosci { get; set; }
        public PagingInfoViewModel PagingInfo { get; set; }
    }
}
