namespace DluzynaSzkola2.Models
{
    public class ApplicationDisplay
    {
        public long ID { get; set; }
        public bool DisplayDark { get; set; } //zaloba
        public string GlownyNaglowekTlo { get; set; } //główny nagłówek strony - glownynaglowektlo
        public string StronaTlo { get; set; } //tło strony - stronatlo - #6fd29b
        public string PrzyciskiKolor { get; set; } //przyciski - przyciskikolor
        public string TrescTlo { get; set; } //tło treści i kolor tekstu naglowkow - tresctlo/tekstnaglowkow
        public string NaglowkiTlo { get; set; } //tło nagłówków - naglowkikolor
        public string TrescKolor { get; set; } //kolor tekstów - tresckolor
        public string StrefaAdminaKolor { get; set; } //kolor napisu "Strefa Admina" - strefaadminakolor
    }
}
