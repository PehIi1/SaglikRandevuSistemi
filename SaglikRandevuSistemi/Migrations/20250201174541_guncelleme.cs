using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SaglikRandevuSistemi.Migrations
{
    /// <inheritdoc />
    public partial class guncelleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrOptions",
                columns: table => new
                {
                    OptionsID = table.Column<int>(type: "integer", nullable: false)
    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DrID = table.Column<int>(type: "integer", nullable: false),
                    opt1 = table.Column<bool>(type: "boolean", nullable: false),
                    opt2 = table.Column<bool>(type: "boolean", nullable: false),
                    opt3 = table.Column<bool>(type: "boolean", nullable: false),
                    opt4 = table.Column<bool>(type: "boolean", nullable: false),
                    opt5 = table.Column<bool>(type: "boolean", nullable: false),
                    opt6 = table.Column<bool>(type: "boolean", nullable: false),
                    opt7 = table.Column<bool>(type: "boolean", nullable: false),
                    opt8 = table.Column<bool>(type: "boolean", nullable: false),
                    Day = table.Column<DateOnly>(type: "date", nullable: false),
                    HastaneID = table.Column<int>(type: "integer", nullable: false),
                    KlinikID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrOptions", x => x.OptionsID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrOptions");
        }
    }
}
