using System;

namespace DluzynaSzkola2.Models
{
    public class Aktualnosci
    {
        public long ID { get; set; }
        public string Tytul { get; set; }
        public string Tresc { get; set; }
        public DateTime Dzien { get; set; }
        public byte[] AktualnosciImage { get; set; }
        public bool Remove { get; set; }
        public string Galeria { get; set; }
    }
}
