﻿using System.ComponentModel.DataAnnotations;

namespace DluzynaSzkola2.Models
{
    public class Rekrutacja
    {
        public long ID { get; set; }
        [Required(ErrorMessage = "Proszę wypełnić pole.")]
        public string Tresc { get; set; }
    }
}
