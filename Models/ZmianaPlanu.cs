using System;

namespace DluzynaSzkola2.Models
{
    public class ZmianaPlanu
    {
        public long ID { get; set; }
        public string Info { get; set; }
        public DateTime DzienRozpoczęcia { get; set; }
        public DateTime DzienZakonczenia { get; set; }
    }
}
