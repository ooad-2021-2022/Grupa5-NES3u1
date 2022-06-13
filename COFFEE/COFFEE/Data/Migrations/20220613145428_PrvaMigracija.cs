using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COFFEE.Data.Migrations
{
    public partial class PrvaMigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Izvjestaj",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumIvrijeme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vrstaIzvjestaja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izvjestaj", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OcjeneProizvoda",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ocjena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OcjeneProizvoda", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Popust",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VrstaProizvoda = table.Column<int>(type: "int", nullable: false),
                    Postotak = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Popust", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeIPrezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDPopusta = table.Column<int>(type: "int", nullable: false),
                    VrstaKorisnika = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Korisnik_Popust_IDPopusta",
                        column: x => x.IDPopusta,
                        principalTable: "Popust",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proizvod",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cijena = table.Column<double>(type: "float", nullable: false),
                    VrstaProizvoda = table.Column<int>(type: "int", nullable: false),
                    IDPopusta = table.Column<int>(type: "int", nullable: false),
                    Ocjena = table.Column<double>(type: "float", nullable: false),
                    VrijemeCekanja = table.Column<int>(type: "int", nullable: false),
                    NutritivnaVrijednost = table.Column<int>(type: "int", nullable: false),
                    NaStanju = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvod", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Proizvod_Popust_IDPopusta",
                        column: x => x.IDPopusta,
                        principalTable: "Popust",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Narudzba",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UkupnaCijena = table.Column<double>(type: "float", nullable: false),
                    DatumIVrijeme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDKorisnika = table.Column<int>(type: "int", nullable: false),
                    StanjeNarudzbe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzba", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Narudzba_Korisnik_IDKorisnika",
                        column: x => x.IDKorisnika,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListaNarudzbi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDIzvjestaja = table.Column<int>(type: "int", nullable: false),
                    IDNarudzbe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaNarudzbi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ListaNarudzbi_Izvjestaj_IDIzvjestaja",
                        column: x => x.IDIzvjestaja,
                        principalTable: "Izvjestaj",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListaNarudzbi_Narudzba_IDNarudzbe",
                        column: x => x.IDNarudzbe,
                        principalTable: "Narudzba",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListaProizvoda",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDProizvoda = table.Column<int>(type: "int", nullable: false),
                    IDNarudzbe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaProizvoda", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ListaProizvoda_Narudzba_IDNarudzbe",
                        column: x => x.IDNarudzbe,
                        principalTable: "Narudzba",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ListaProizvoda_Proizvod_IDProizvoda",
                        column: x => x.IDProizvoda,
                        principalTable: "Proizvod",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Placanje",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VrstaPlacanja = table.Column<int>(type: "int", nullable: false),
                    IDKorisnika = table.Column<int>(type: "int", nullable: false),
                    Popust = table.Column<bool>(type: "bit", nullable: false),
                    IDNarudzbe = table.Column<int>(type: "int", nullable: false),
                    EvidencijaUplate = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placanje", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Placanje_Korisnik_IDKorisnika",
                        column: x => x.IDKorisnika,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Placanje_Narudzba_IDNarudzbe",
                        column: x => x.IDNarudzbe,
                        principalTable: "Narudzba",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RedCekanja",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDNarudzbe = table.Column<int>(type: "int", nullable: false),
                    IDKorisnik = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedCekanja", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RedCekanja_Korisnik_IDKorisnik",
                        column: x => x.IDKorisnik,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RedCekanja_Narudzba_IDNarudzbe",
                        column: x => x.IDNarudzbe,
                        principalTable: "Narudzba",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_IDPopusta",
                table: "Korisnik",
                column: "IDPopusta");

            migrationBuilder.CreateIndex(
                name: "IX_ListaNarudzbi_IDIzvjestaja",
                table: "ListaNarudzbi",
                column: "IDIzvjestaja");

            migrationBuilder.CreateIndex(
                name: "IX_ListaNarudzbi_IDNarudzbe",
                table: "ListaNarudzbi",
                column: "IDNarudzbe");

            migrationBuilder.CreateIndex(
                name: "IX_ListaProizvoda_IDNarudzbe",
                table: "ListaProizvoda",
                column: "IDNarudzbe");

            migrationBuilder.CreateIndex(
                name: "IX_ListaProizvoda_IDProizvoda",
                table: "ListaProizvoda",
                column: "IDProizvoda");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_IDKorisnika",
                table: "Narudzba",
                column: "IDKorisnika");

            migrationBuilder.CreateIndex(
                name: "IX_Placanje_IDKorisnika",
                table: "Placanje",
                column: "IDKorisnika");

            migrationBuilder.CreateIndex(
                name: "IX_Placanje_IDNarudzbe",
                table: "Placanje",
                column: "IDNarudzbe");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_IDPopusta",
                table: "Proizvod",
                column: "IDPopusta");

            migrationBuilder.CreateIndex(
                name: "IX_RedCekanja_IDKorisnik",
                table: "RedCekanja",
                column: "IDKorisnik");

            migrationBuilder.CreateIndex(
                name: "IX_RedCekanja_IDNarudzbe",
                table: "RedCekanja",
                column: "IDNarudzbe");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListaNarudzbi");

            migrationBuilder.DropTable(
                name: "ListaProizvoda");

            migrationBuilder.DropTable(
                name: "OcjeneProizvoda");

            migrationBuilder.DropTable(
                name: "Placanje");

            migrationBuilder.DropTable(
                name: "RedCekanja");

            migrationBuilder.DropTable(
                name: "Izvjestaj");

            migrationBuilder.DropTable(
                name: "Proizvod");

            migrationBuilder.DropTable(
                name: "Narudzba");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Popust");
        }
    }
}
