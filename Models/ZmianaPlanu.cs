using System;
using System.ComponentModel.DataAnnotations;

namespace DluzynaSzkola2.Models
{
    public class ZmianaPlanu
    {
        public long ID { get; set; }
        [Required(ErrorMessage = "Proszę wypełnić pole.")]
        public string Info { get; set; }
        public DateTime DzienRozpoczęcia { get; set; }
        [Required(ErrorMessage = "Proszę wypełnić pole.")]
        public DateTime DzienZakonczenia { get; set; }
    }
}
