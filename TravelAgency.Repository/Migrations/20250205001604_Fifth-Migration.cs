using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Repository.Migrations
{
    /// <inheritdoc />
    public partial class FifthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartureDates",
                table: "TravelPackages");

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureDate",
                table: "TravelPackages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartureDate",
                table: "TravelPackages");

            migrationBuilder.AddColumn<string>(
                name: "DepartureDates",
                table: "TravelPackages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
