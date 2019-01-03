using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace DluzynaSzkola2.Models.ViewModels
{
    public class AktualnosciCreateVM
    {
        public long ID { get; set; }
        [Required(ErrorMessage = "Proszę wypełnić pole.")]
        [StringLength(40, ErrorMessage = "Max 40 znaków.")]
        public string Tytul { get; set; }
        [Required(ErrorMessage = "Proszę wypełnić pole.")]
        public string Tresc { get; set; }
        [Required(ErrorMessage = "Proszę wypełnić pole.")]
        public DateTime Dzien { get; set; }
        public IFormFile AktualnosciImage { set; get; }
        public byte[] CurrentImage { get; set; }
        public bool Remove { get; set; }
        public string Galeria { get; set; }
    }
}
