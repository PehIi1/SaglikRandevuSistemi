using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaglikRandevuSistemi.Migrations
{
    /// <inheritdoc />
    public partial class droptionsv4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "RandevuGun",
                table: "Randevu",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RandevuGun",
                table: "Randevu");
        }
    }
}
