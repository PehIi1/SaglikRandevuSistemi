using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SaglikRandevuSistemi.Migrations
{
    /// <inheritdoc />
    public partial class droptionsv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.CreateTable(
                name: "Randevu",
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
                    table.PrimaryKey("PK_Randevu", x => x.RandID);
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropTable(
                name: "Randevu");

            
        }
    }
}
