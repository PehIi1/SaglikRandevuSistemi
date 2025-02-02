using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SaglikRandevuSistemi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinsiyetlers",
                columns: table => new
                {
                    CinsiyetID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CinsiyetAdi = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinsiyetlers", x => x.CinsiyetID);
                });

            migrationBuilder.CreateTable(
                name: "Kliniklers",
                columns: table => new
                {
                    KlinikID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KlinikAdi = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kliniklers", x => x.KlinikID);
                });

            migrationBuilder.CreateTable(
                name: "RandevuDurumlaris",
                columns: table => new
                {
                    RandDurumID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RandDurumAdi = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandevuDurumlaris", x => x.RandDurumID);
                });

            migrationBuilder.CreateTable(
                name: "RandevuSaatleris",
                columns: table => new
                {
                    RandSaatID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RandSaatTarihi = table.Column<DateOnly>(type: "date", nullable: false),
                    RandSaatZamani = table.Column<TimeOnly>(type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandevuSaatleris", x => x.RandSaatID);
                });

            migrationBuilder.CreateTable(
                name: "Rollers",
                columns: table => new
                {
                    RolID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RolAdi = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rollers", x => x.RolID);
                });

            migrationBuilder.CreateTable(
                name: "Sehirlers",
                columns: table => new
                {
                    SehirID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SehirAdi = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sehirlers", x => x.SehirID);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilars",
                columns: table => new
                {
                    KullaniciID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KullaniciAdi = table.Column<string>(type: "text", nullable: true),
                    Parola = table.Column<string>(type: "text", nullable: true),
                    RolID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilars", x => x.KullaniciID);
                    table.ForeignKey(
                        name: "FK_Kullanicilars_Rollers_RolID",
                        column: x => x.RolID,
                        principalTable: "Rollers",
                        principalColumn: "RolID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ilcelers",
                columns: table => new
                {
                    IlceID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IlceAdi = table.Column<string>(type: "text", nullable: true),
                    SehirID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilcelers", x => x.IlceID);
                    table.ForeignKey(
                        name: "FK_Ilcelers_Sehirlers_SehirID",
                        column: x => x.SehirID,
                        principalTable: "Sehirlers",
                        principalColumn: "SehirID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hastalars",
                columns: table => new
                {
                    HastaID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HastaAdi = table.Column<string>(type: "text", nullable: true),
                    HastaSoyadi = table.Column<string>(type: "text", nullable: true),
                    HastaYas = table.Column<string>(type: "text", nullable: true),
                    HastaBoy = table.Column<string>(type: "text", nullable: true),
                    HastaKilo = table.Column<string>(type: "text", nullable: true),
                    HastaTel = table.Column<string>(type: "text", nullable: true),
                    HastaEmail = table.Column<string>(type: "text", nullable: true),
                    HastaAdres = table.Column<string>(type: "text", nullable: true),
                    SehirID = table.Column<int>(type: "integer", nullable: true),
                    IlceID = table.Column<int>(type: "integer", nullable: true),
                    CinsiyetID = table.Column<int>(type: "integer", nullable: true),
                    KullaniciID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastalars", x => x.HastaID);
                    table.ForeignKey(
                        name: "FK_Hastalars_Cinsiyetlers_CinsiyetID",
                        column: x => x.CinsiyetID,
                        principalTable: "Cinsiyetlers",
                        principalColumn: "CinsiyetID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hastalars_Ilcelers_IlceID",
                        column: x => x.IlceID,
                        principalTable: "Ilcelers",
                        principalColumn: "IlceID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hastalars_Kullanicilars_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanicilars",
                        principalColumn: "KullaniciID");
                    table.ForeignKey(
                        name: "FK_Hastalars_Sehirlers_SehirID",
                        column: x => x.SehirID,
                        principalTable: "Sehirlers",
                        principalColumn: "SehirID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hastanelers",
                columns: table => new
                {
                    HastaneID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HastaneAdi = table.Column<string>(type: "text", nullable: true),
                    SehirID = table.Column<int>(type: "integer", nullable: true),
                    IlceID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastanelers", x => x.HastaneID);
                    table.ForeignKey(
                        name: "FK_Hastanelers_Ilcelers_IlceID",
                        column: x => x.IlceID,
                        principalTable: "Ilcelers",
                        principalColumn: "IlceID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hastanelers_Sehirlers_SehirID",
                        column: x => x.SehirID,
                        principalTable: "Sehirlers",
                        principalColumn: "SehirID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doktorlars",
                columns: table => new
                {
                    DrID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DrAdi = table.Column<string>(type: "text", nullable: true),
                    DrSoyadi = table.Column<string>(type: "text", nullable: true),
                    DrYas = table.Column<string>(type: "text", nullable: true),
                    DrTel = table.Column<string>(type: "text", nullable: true),
                    DrEmail = table.Column<string>(type: "text", nullable: true),
                    KlinikID = table.Column<int>(type: "integer", nullable: true),
                    HastaneID = table.Column<int>(type: "integer", nullable: true),
                    CinsiyetID = table.Column<int>(type: "integer", nullable: true),
                    KullaniciID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doktorlars", x => x.DrID);
                    table.ForeignKey(
                        name: "FK_Doktorlars_Cinsiyetlers_CinsiyetID",
                        column: x => x.CinsiyetID,
                        principalTable: "Cinsiyetlers",
                        principalColumn: "CinsiyetID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doktorlars_Hastanelers_HastaneID",
                        column: x => x.HastaneID,
                        principalTable: "Hastanelers",
                        principalColumn: "HastaneID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doktorlars_Kliniklers_KlinikID",
                        column: x => x.KlinikID,
                        principalTable: "Kliniklers",
                        principalColumn: "KlinikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doktorlars_Kullanicilars_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanicilars",
                        principalColumn: "KullaniciID");
                });

            migrationBuilder.CreateTable(
                name: "HastaneKlinikleris",
                columns: table => new
                {
                    HastaneID = table.Column<int>(type: "integer", nullable: false),
                    KlinikID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HastaneKlinikleris", x => new { x.HastaneID, x.KlinikID });
                    table.ForeignKey(
                        name: "FK_HastaneKlinikleris_Hastanelers_HastaneID",
                        column: x => x.HastaneID,
                        principalTable: "Hastanelers",
                        principalColumn: "HastaneID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HastaneKlinikleris_Kliniklers_KlinikID",
                        column: x => x.KlinikID,
                        principalTable: "Kliniklers",
                        principalColumn: "KlinikID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Randevulars",
                columns: table => new
                {
                    RandID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HastaID = table.Column<int>(type: "integer", nullable: true),
                    DoktorID = table.Column<int>(type: "integer", nullable: true),
                    HastaneID = table.Column<int>(type: "integer", nullable: true),
                    RandSaatID = table.Column<int>(type: "integer", nullable: true),
                    RandDurumID = table.Column<int>(type: "integer", nullable: true),
                    KlinikID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevulars", x => x.RandID);
                    table.ForeignKey(
                        name: "FK_Randevulars_Doktorlars_DoktorID",
                        column: x => x.DoktorID,
                        principalTable: "Doktorlars",
                        principalColumn: "DrID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Randevulars_Hastalars_HastaID",
                        column: x => x.HastaID,
                        principalTable: "Hastalars",
                        principalColumn: "HastaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Randevulars_Hastanelers_HastaneID",
                        column: x => x.HastaneID,
                        principalTable: "Hastanelers",
                        principalColumn: "HastaneID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Randevulars_Kliniklers_KlinikID",
                        column: x => x.KlinikID,
                        principalTable: "Kliniklers",
                        principalColumn: "KlinikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Randevulars_RandevuDurumlaris_RandDurumID",
                        column: x => x.RandDurumID,
                        principalTable: "RandevuDurumlaris",
                        principalColumn: "RandDurumID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Randevulars_RandevuSaatleris_RandSaatID",
                        column: x => x.RandSaatID,
                        principalTable: "RandevuSaatleris",
                        principalColumn: "RandSaatID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlars_CinsiyetID",
                table: "Doktorlars",
                column: "CinsiyetID");

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlars_HastaneID",
                table: "Doktorlars",
                column: "HastaneID");

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlars_KlinikID",
                table: "Doktorlars",
                column: "KlinikID");

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlars_KullaniciID",
                table: "Doktorlars",
                column: "KullaniciID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hastalars_CinsiyetID",
                table: "Hastalars",
                column: "CinsiyetID");

            migrationBuilder.CreateIndex(
                name: "IX_Hastalars_IlceID",
                table: "Hastalars",
                column: "IlceID");

            migrationBuilder.CreateIndex(
                name: "IX_Hastalars_KullaniciID",
                table: "Hastalars",
                column: "KullaniciID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hastalars_SehirID",
                table: "Hastalars",
                column: "SehirID");

            migrationBuilder.CreateIndex(
                name: "IX_HastaneKlinikleris_KlinikID",
                table: "HastaneKlinikleris",
                column: "KlinikID");

            migrationBuilder.CreateIndex(
                name: "IX_Hastanelers_IlceID",
                table: "Hastanelers",
                column: "IlceID");

            migrationBuilder.CreateIndex(
                name: "IX_Hastanelers_SehirID",
                table: "Hastanelers",
                column: "SehirID");

            migrationBuilder.CreateIndex(
                name: "IX_Ilcelers_SehirID",
                table: "Ilcelers",
                column: "SehirID");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilars_RolID",
                table: "Kullanicilars",
                column: "RolID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevulars_DoktorID",
                table: "Randevulars",
                column: "DoktorID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevulars_HastaID",
                table: "Randevulars",
                column: "HastaID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevulars_HastaneID",
                table: "Randevulars",
                column: "HastaneID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevulars_KlinikID",
                table: "Randevulars",
                column: "KlinikID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevulars_RandDurumID",
                table: "Randevulars",
                column: "RandDurumID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevulars_RandSaatID",
                table: "Randevulars",
                column: "RandSaatID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HastaneKlinikleris");

            migrationBuilder.DropTable(
                name: "Randevulars");

            migrationBuilder.DropTable(
                name: "Doktorlars");

            migrationBuilder.DropTable(
                name: "Hastalars");

            migrationBuilder.DropTable(
                name: "RandevuDurumlaris");

            migrationBuilder.DropTable(
                name: "RandevuSaatleris");

            migrationBuilder.DropTable(
                name: "Hastanelers");

            migrationBuilder.DropTable(
                name: "Kliniklers");

            migrationBuilder.DropTable(
                name: "Cinsiyetlers");

            migrationBuilder.DropTable(
                name: "Kullanicilars");

            migrationBuilder.DropTable(
                name: "Ilcelers");

            migrationBuilder.DropTable(
                name: "Rollers");

            migrationBuilder.DropTable(
                name: "Sehirlers");
        }
    }
}
