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
        public bool DisplayDark { get; set; }
        public string GlownyNaglowekTlo { get; set; }
        public string StronaTlo { get; set; }
        public string PrzyciskiKolor { get; set; }
        public string TrescTlo { get; set; }
        public string NaglowkiTlo { get; set; }
        public string TrescKolor { get; set; }
        public string StrefaAdminaKolor { get; set; }
    }
}
