using System.ComponentModel.DataAnnotations;

namespace DluzynaSzkola2.Models
{
    public class Podreczniki
    {
        public long ID { get; set; }
        [Required(ErrorMessage = "Proszę wypełnić pole.")]
        public string Tresc { get; set; }
    }
}
