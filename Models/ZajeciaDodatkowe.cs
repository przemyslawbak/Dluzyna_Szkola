using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public class ZajeciaDodatkowe
    {
        public long ID { get; set; }
        [Required]
        public string Tresc { get; set; }
    }
}
