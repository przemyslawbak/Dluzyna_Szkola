using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>
            options) : base(options) { }
        public DbSet<Aktualnosci> Aktualnosci { get; set; }
        public DbSet<Historia> Historias { get; set; }
        public DbSet<Dokumenty> Dokumentys { get; set; }
        public DbSet<RadaRodzicow> RadaRodzicows { get; set; }
        public DbSet<Podreczniki> Podrecznikis { get; set; }
        public DbSet<Wyprawka> Wyprawkas { get; set; }
        public DbSet<Rekrutacja> Rekrutacjas { get; set; }
        public DbSet<Samorzad> Samorzads { get; set; }
        public DbSet<ZajeciaDodatkowe> ZajeciaDodatkowes { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Autobus> Autobuses { get; set; }
        public DbSet<Konkursy> Konkursys { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Biblioteka> Bibliotekas { get; set; }
        public DbSet<GronoPedagogiczne> GronoPedagogicznes { get; set; }
        public DbSet<Sukcesy> Sukcesys { get; set; }
        public DbSet<Wydarzenia> Wydarzenias { get; set; }
        public DbSet<Solectwo> Solectwos { get; set; }
        public DbSet<ApplicationDisplay> ApplicationDisplays { get; set; }
        public DbSet<Kontakt> Kontakts { get; set; }
        public DbSet<ZmianaPlanu> ZmianaPlanus { get; set; }
    }
}
