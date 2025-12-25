using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinterEquipmentRentalApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedRentalReturnEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentHours",
                table: "Rentals");

            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "Rentals",
                newName: "PricePerHour");

            migrationBuilder.AddColumn<DateTime>(
                name: "RentalDate",
                table: "Rentals",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "RentalReturns",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RentalId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalReturns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentalReturns_Rentals_RentalId",
                        column: x => x.RentalId,
                        principalTable: "Rentals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalReturns_RentalId",
                table: "RentalReturns",
                column: "RentalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentalReturns");

            migrationBuilder.DropColumn(
                name: "RentalDate",
                table: "Rentals");

            migrationBuilder.RenameColumn(
                name: "PricePerHour",
                table: "Rentals",
                newName: "Cost");

            migrationBuilder.AddColumn<int>(
                name: "RentHours",
                table: "Rentals",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
