using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Repository.Migrations
{
    /// <inheritdoc />
    public partial class _0007 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravelPackageAccommodationStay");

            migrationBuilder.AddColumn<Guid>(
                name: "AccommodationId",
                table: "TravelPackages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AvailableRooms",
                table: "TravelPackages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TravelPackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfRooms = table.Column<int>(type: "int", nullable: false),
                    FullPrice = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_TravelPackages_TravelPackageId",
                        column: x => x.TravelPackageId,
                        principalTable: "TravelPackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TravelPackages_AccommodationId",
                table: "TravelPackages",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TravelPackageId",
                table: "Bookings",
                column: "TravelPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId1",
                table: "Bookings",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelPackages_Accommodations_AccommodationId",
                table: "TravelPackages",
                column: "AccommodationId",
                principalTable: "Accommodations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelPackages_Accommodations_AccommodationId",
                table: "TravelPackages");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_TravelPackages_AccommodationId",
                table: "TravelPackages");

            migrationBuilder.DropColumn(
                name: "AccommodationId",
                table: "TravelPackages");

            migrationBuilder.DropColumn(
                name: "AvailableRooms",
                table: "TravelPackages");

            migrationBuilder.CreateTable(
                name: "TravelPackageAccommodationStay",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccommodationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TravelPackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AvailableRooms = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelPackageAccommodationStay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelPackageAccommodationStay_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TravelPackageAccommodationStay_TravelPackages_TravelPackageId",
                        column: x => x.TravelPackageId,
                        principalTable: "TravelPackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TravelPackageAccommodationStay_AccommodationId",
                table: "TravelPackageAccommodationStay",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelPackageAccommodationStay_TravelPackageId",
                table: "TravelPackageAccommodationStay",
                column: "TravelPackageId");
        }
    }
}
