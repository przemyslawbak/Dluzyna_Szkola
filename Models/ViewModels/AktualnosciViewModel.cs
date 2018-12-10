using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models.ViewModels
{
    public class AktualnosciViewModel
    {
        public IEnumerable<Aktualnosci> ListOfAktualnosci { get; set; }
        public PagingInfoViewModel PagingInfo { get; set; }
    }
}
