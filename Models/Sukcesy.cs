using System.ComponentModel.DataAnnotations;

namespace DluzynaSzkola2.Models
{
    public class Sukcesy
    {
        public long ID { get; set; }
        [Required(ErrorMessage = "Proszę wypełnić pole.")]
        [StringLength(30, ErrorMessage = "Max 30 znaków")]
        public string Tytul { get; set; }
        [Required(ErrorMessage = "Proszę wypełnić pole.")]
        public string Tresc { get; set; }
    }
}
