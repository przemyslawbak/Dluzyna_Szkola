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
        public string GlownyNaglowekTlo { get; set; } //główny nagłówek strony - glownynaglowektlo - #4c4035
        public string StronaTlo { get; set; } //tło strony - stronatlo - #6fd29b
        public string PrzyciskiKolor { get; set; } //przyciski - przyciskikolor - #ff9b2d
        public string TrescTlo { get; set; } //tło treści i kolor tekstu naglowkow - tresctlo/tekstnaglowkow - #ffebcd
        public string NaglowkiTlo { get; set; } //tło nagłówków - naglowkikolor - #cc5a38
        public string TrescKolor { get; set; } //kolor tekstów - tresckolor - #4C4034
        public string StrefaAdminaKolor { get; set; } //kolor napisu "Strefa Admina" - strefaadminakolor - #008039
    }
}
