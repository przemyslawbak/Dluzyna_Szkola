using System.ComponentModel.DataAnnotations;

namespace DluzynaSzkola2.Models
{
    public class Kontakt
    {
        public long ID { get; set; }
        [Required(ErrorMessage = "Proszę wypełnić pole.")]
        public string AdresUlica { get; set; }
        [Required(ErrorMessage = "Proszę wypełnić pole.")]
        public string AdresMiastoKod { get; set; }
        [Required(ErrorMessage = "Proszę wypełnić pole.")]
        public string AdresWojewodztwo { get; set; }
        [Required(ErrorMessage = "Proszę wypełnić pole.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Proszę wypełnić pole.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Proszę wypełnić pole.")]
        public string Fax { get; set; }
        [Required(ErrorMessage = "Proszę wypełnić pole.")]
        public string LinkGoogleMaps { get; set; }
    }
}
