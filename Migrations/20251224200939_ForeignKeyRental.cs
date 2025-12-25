using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinterEquipmentRentalApi.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyRental : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RentalReturns_RentalId",
                table: "RentalReturns");

            migrationBuilder.CreateIndex(
                name: "IX_RentalReturns_RentalId",
                table: "RentalReturns",
                column: "RentalId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RentalReturns_RentalId",
                table: "RentalReturns");

            migrationBuilder.CreateIndex(
                name: "IX_RentalReturns_RentalId",
                table: "RentalReturns",
                column: "RentalId");
        }
    }
}
