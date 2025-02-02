using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaglikRandevuSistemi.Migrations
{
    /// <inheritdoc />
    public partial class son : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "DrOptions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "Day",
                table: "DrOptions",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DrName",
                table: "DrOptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HastaneID",
                table: "DrOptions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KlinikID",
                table: "DrOptions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "opt1",
                table: "DrOptions",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "opt2",
                table: "DrOptions",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "opt3",
                table: "DrOptions",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "opt4",
                table: "DrOptions",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "opt5",
                table: "DrOptions",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "opt6",
                table: "DrOptions",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "opt7",
                table: "DrOptions",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "opt8",
                table: "DrOptions",
                type: "boolean",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityId",
                table: "DrOptions");

            migrationBuilder.DropColumn(
                name: "Day",
                table: "DrOptions");

            migrationBuilder.DropColumn(
                name: "DrName",
                table: "DrOptions");

            migrationBuilder.DropColumn(
                name: "HastaneID",
                table: "DrOptions");

            migrationBuilder.DropColumn(
                name: "KlinikID",
                table: "DrOptions");

            migrationBuilder.DropColumn(
                name: "opt1",
                table: "DrOptions");

            migrationBuilder.DropColumn(
                name: "opt2",
                table: "DrOptions");

            migrationBuilder.DropColumn(
                name: "opt3",
                table: "DrOptions");

            migrationBuilder.DropColumn(
                name: "opt4",
                table: "DrOptions");

            migrationBuilder.DropColumn(
                name: "opt5",
                table: "DrOptions");

            migrationBuilder.DropColumn(
                name: "opt6",
                table: "DrOptions");

            migrationBuilder.DropColumn(
                name: "opt7",
                table: "DrOptions");

            migrationBuilder.DropColumn(
                name: "opt8",
                table: "DrOptions");
        }
    }
}
