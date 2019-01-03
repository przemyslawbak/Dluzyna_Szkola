using System.ComponentModel.DataAnnotations;

namespace DluzynaSzkola2.Models
{
    public class GronoPedagogiczne
    {
        public long ID { get; set; }
        [Required(ErrorMessage = "Proszę wypełnić pole.")]
        public string Imie { get; set; }
        [Required(ErrorMessage = "Proszę wypełnić pole.")]
        public string Nazwisko { get; set; }
        [Required(ErrorMessage = "Proszę wypełnić pole.")]
        public string Funkcje { get; set; }
        public string Zdjecie { get; set; }
    }
}
