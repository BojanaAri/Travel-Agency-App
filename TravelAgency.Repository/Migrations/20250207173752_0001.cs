using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Repository.Migrations
{
    /// <inheritdoc />
    public partial class _0001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "FullPrice",
                table: "Bookings",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FullPrice",
                table: "Bookings",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
