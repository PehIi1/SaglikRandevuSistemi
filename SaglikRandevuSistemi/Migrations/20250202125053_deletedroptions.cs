using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SaglikRandevuSistemi.Migrations
{
    /// <inheritdoc />
    public partial class deletedroptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrOptions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrOptions",
                columns: table => new
                {
                    OptionsID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CityId = table.Column<int>(type: "integer", nullable: true),
                    Day = table.Column<DateOnly>(type: "date", nullable: true),
                    DrID = table.Column<int>(type: "integer", nullable: true),
                    DrName = table.Column<string>(type: "text", nullable: true),
                    HastaneID = table.Column<int>(type: "integer", nullable: true),
                    KlinikID = table.Column<int>(type: "integer", nullable: true),
                    opt1 = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    opt2 = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    opt3 = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    opt4 = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    opt5 = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    opt6 = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    opt7 = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    opt8 = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrOptions", x => x.OptionsID);
                });
        }
    }
}
