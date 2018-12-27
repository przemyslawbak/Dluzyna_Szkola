using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public class ApplicationDisplay
    {
        public long ID { get; set; }
        public bool DisplayDark { get; set; } //zaloba
        public string GlownyNaglowekTlo { get; set; } //główny nagłówek strony
        public string StronaTlo { get; set; } //tło strony
        public string PrzyciskiKolor { get; set; } //przyciski
        public string TrescTlo { get; set; } //tło treści i kolor tekstu nagłówków
        public string NaglowkiTlo { get; set; } //tło nagłówków
        public string TrescKolor { get; set; } //kolor tekstów
        public string StrefaAdminaKolor { get; set; } //kolor napisu "Strefa Admina"
    }
}
