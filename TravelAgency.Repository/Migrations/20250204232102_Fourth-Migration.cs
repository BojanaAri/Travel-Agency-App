using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Repository.Migrations
{
    /// <inheritdoc />
    public partial class FourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelDates_Accommodations_AccommodationId",
                table: "TravelDates");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelDates_TravelPackages_TravelPackageId",
                table: "TravelDates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TravelDates",
                table: "TravelDates");

            migrationBuilder.RenameTable(
                name: "TravelDates",
                newName: "TravelPackageAccommodationStay");

            migrationBuilder.RenameIndex(
                name: "IX_TravelDates_TravelPackageId",
                table: "TravelPackageAccommodationStay",
                newName: "IX_TravelPackageAccommodationStay_TravelPackageId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelDates_AccommodationId",
                table: "TravelPackageAccommodationStay",
                newName: "IX_TravelPackageAccommodationStay_AccommodationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TravelPackageAccommodationStay",
                table: "TravelPackageAccommodationStay",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelPackageAccommodationStay_Accommodations_AccommodationId",
                table: "TravelPackageAccommodationStay",
                column: "AccommodationId",
                principalTable: "Accommodations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelPackageAccommodationStay_TravelPackages_TravelPackageId",
                table: "TravelPackageAccommodationStay",
                column: "TravelPackageId",
                principalTable: "TravelPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelPackageAccommodationStay_Accommodations_AccommodationId",
                table: "TravelPackageAccommodationStay");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelPackageAccommodationStay_TravelPackages_TravelPackageId",
                table: "TravelPackageAccommodationStay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TravelPackageAccommodationStay",
                table: "TravelPackageAccommodationStay");

            migrationBuilder.RenameTable(
                name: "TravelPackageAccommodationStay",
                newName: "TravelDates");

            migrationBuilder.RenameIndex(
                name: "IX_TravelPackageAccommodationStay_TravelPackageId",
                table: "TravelDates",
                newName: "IX_TravelDates_TravelPackageId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelPackageAccommodationStay_AccommodationId",
                table: "TravelDates",
                newName: "IX_TravelDates_AccommodationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TravelDates",
                table: "TravelDates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelDates_Accommodations_AccommodationId",
                table: "TravelDates",
                column: "AccommodationId",
                principalTable: "Accommodations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelDates_TravelPackages_TravelPackageId",
                table: "TravelDates",
                column: "TravelPackageId",
                principalTable: "TravelPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
