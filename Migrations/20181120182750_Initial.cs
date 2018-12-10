using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DluzynaSzkola2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aktualnosci",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tytul = table.Column<string>(nullable: true),
                    Tresc = table.Column<string>(nullable: true),
                    Dzien = table.Column<DateTime>(nullable: false),
                    AktualnosciImage = table.Column<byte[]>(nullable: true),
                    Remove = table.Column<bool>(nullable: false),
                    Galeria = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aktualnosci", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationDisplays",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DisplayDark = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationDisplays", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Autobuses",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tresc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autobuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Bibliotekas",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tresc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bibliotekas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Dokumentys",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tresc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokumentys", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GronoPedagogicznes",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Imie = table.Column<string>(nullable: false),
                    Nazwisko = table.Column<string>(nullable: false),
                    Funkcje = table.Column<string>(nullable: false),
                    Zdjecie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GronoPedagogicznes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Historias",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tresc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historias", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Konkursys",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tresc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konkursys", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tresc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Podrecznikis",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tresc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podrecznikis", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RadaRodzicows",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tresc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadaRodzicows", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rekrutacjas",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tresc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rekrutacjas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Samorzads",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tresc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samorzads", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Solectwos",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tresc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solectwos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tresc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sukcesys",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tytul = table.Column<string>(maxLength: 30, nullable: false),
                    Tresc = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sukcesys", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Wydarzenias",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 40, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    WhenHappens = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wydarzenias", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Wyprawkas",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tresc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wyprawkas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ZajeciaDodatkowes",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tresc = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZajeciaDodatkowes", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aktualnosci");

            migrationBuilder.DropTable(
                name: "ApplicationDisplays");

            migrationBuilder.DropTable(
                name: "Autobuses");

            migrationBuilder.DropTable(
                name: "Bibliotekas");

            migrationBuilder.DropTable(
                name: "Dokumentys");

            migrationBuilder.DropTable(
                name: "GronoPedagogicznes");

            migrationBuilder.DropTable(
                name: "Historias");

            migrationBuilder.DropTable(
                name: "Konkursys");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Podrecznikis");

            migrationBuilder.DropTable(
                name: "RadaRodzicows");

            migrationBuilder.DropTable(
                name: "Rekrutacjas");

            migrationBuilder.DropTable(
                name: "Samorzads");

            migrationBuilder.DropTable(
                name: "Solectwos");

            migrationBuilder.DropTable(
                name: "Sports");

            migrationBuilder.DropTable(
                name: "Sukcesys");

            migrationBuilder.DropTable(
                name: "Wydarzenias");

            migrationBuilder.DropTable(
                name: "Wyprawkas");

            migrationBuilder.DropTable(
                name: "ZajeciaDodatkowes");
        }
    }
}
