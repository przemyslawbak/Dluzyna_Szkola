using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public class Kontakt
    {
        public long ID { get; set; }
        public string AdresUlica { get; set; }
        public string AdresMiastoKod { get; set; }
        public string AdresWojewodztwo { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string LinkGoogleMaps { get; set; }
    }
}
