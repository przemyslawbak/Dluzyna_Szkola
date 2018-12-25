﻿// <auto-generated />
using System;
using DluzynaSzkola2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DluzynaSzkola2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DluzynaSzkola2.Models.Aktualnosci", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("AktualnosciImage");

                    b.Property<DateTime>("Dzien");

                    b.Property<string>("Galeria");

                    b.Property<bool>("Remove");

                    b.Property<string>("Tresc");

                    b.Property<string>("Tytul");

                    b.HasKey("ID");

                    b.ToTable("Aktualnosci");
                });

            modelBuilder.Entity("DluzynaSzkola2.Models.ApplicationDisplay", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("DisplayDark");

                    b.Property<string>("GlownyNaglowekTlo");

                    b.Property<string>("NaglowkiTlo");

                    b.Property<string>("PrzyciskiKolor");

                    b.Property<string>("StrefaAdminaKolor");

                    b.Property<string>("StronaTlo");

                    b.Property<string>("TrescKolor");

                    b.Property<string>("TrescTlo");

                    b.HasKey("ID");

                    b.ToTable("ApplicationDisplays");
                });

            modelBuilder.Entity("DluzynaSzkola2.Models.Autobus", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tresc");

                    b.HasKey("ID");

                    b.ToTable("Autobuses");
                });

            modelBuilder.Entity("DluzynaSzkola2.Models.Biblioteka", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tresc");

                    b.HasKey("ID");

                    b.ToTable("Bibliotekas");
                });

            modelBuilder.Entity("DluzynaSzkola2.Models.Dokumenty", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tresc");

                    b.HasKey("ID");

                    b.ToTable("Dokumentys");
                });

            modelBuilder.Entity("DluzynaSzkola2.Models.GronoPedagogiczne", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Funkcje")
                        .IsRequired();

                    b.Property<string>("Imie")
                        .IsRequired();

                    b.Property<string>("Nazwisko")
                        .IsRequired();

                    b.Property<string>("Zdjecie");

                    b.HasKey("ID");

                    b.ToTable("GronoPedagogicznes");
                });

            modelBuilder.Entity("DluzynaSzkola2.Models.Historia", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tresc");

                    b.HasKey("ID");

                    b.ToTable("Historias");
                });

            modelBuilder.Entity("DluzynaSzkola2.Models.Konkursy", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tresc");

                    b.HasKey("ID");

                    b.ToTable("Konkursys");
                });

            modelBuilder.Entity("DluzynaSzkola2.Models.Kontakt", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdresMiastoKod");

                    b.Property<string>("AdresUlica");

                    b.Property<string>("AdresWojewodztwo");

                    b.Property<string>("Email");

                    b.Property<string>("Fax");

                    b.Property<string>("LinkGoogleMaps");

                    b.Property<string>("Phone");

                    b.HasKey("ID");

                    b.ToTable("Kontakts");
                });

            modelBuilder.Entity("DluzynaSzkola2.Models.Plan", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tresc");

                    b.HasKey("ID");

                    b.ToTable("Plans");
                });

            modelBuilder.Entity("DluzynaSzkola2.Models.Podreczniki", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tresc");

                    b.HasKey("ID");

                    b.ToTable("Podrecznikis");
                });

            modelBuilder.Entity("DluzynaSzkola2.Models.RadaRodzicow", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tresc");

                    b.HasKey("ID");

                    b.ToTable("RadaRodzicows");
                });

            modelBuilder.Entity("DluzynaSzkola2.Models.Rekrutacja", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tresc");

                    b.HasKey("ID");

                    b.ToTable("Rekrutacjas");
                });

            modelBuilder.Entity("DluzynaSzkola2.Models.Samorzad", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tresc");

                    b.HasKey("ID");

                    b.ToTable("Samorzads");
                });

            modelBuilder.Entity("DluzynaSzkola2.Models.Solectwo", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tresc");

                    b.HasKey("ID");

                    b.ToTable("Solectwos");
                });

            modelBuilder.Entity("DluzynaSzkola2.Models.Sport", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tresc");

                    b.HasKey("ID");

                    b.ToTable("Sports");
                });

            modelBuilder.Entity("DluzynaSzkola2.Models.Sukcesy", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tresc")
                        .IsRequired();

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("ID");

                    b.ToTable("Sukcesys");
                });

            modelBuilder.Entity("DluzynaSzkola2.Models.Wydarzenia", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<DateTime>("WhenHappens");

                    b.HasKey("ID");

                    b.ToTable("Wydarzenias");
                });

            modelBuilder.Entity("DluzynaSzkola2.Models.Wyprawka", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tresc");

                    b.HasKey("ID");

                    b.ToTable("Wyprawkas");
                });

            modelBuilder.Entity("DluzynaSzkola2.Models.ZajeciaDodatkowe", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tresc")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("ZajeciaDodatkowes");
                });

            modelBuilder.Entity("DluzynaSzkola2.Models.ZmianaPlanu", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DzienRozpoczęcia");

                    b.Property<DateTime>("DzienZakonczenia");

                    b.Property<string>("Info");

                    b.HasKey("ID");

                    b.ToTable("ZmianaPlanus");
                });
#pragma warning restore 612, 618
        }
    }
}
