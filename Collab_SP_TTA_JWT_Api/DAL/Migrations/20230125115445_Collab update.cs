using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Collabupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Persons_DriverLicenseId",
                table: "Persons",
                column: "DriverLicenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_DriverLicenses_DriverLicenseId",
                table: "Persons",
                column: "DriverLicenseId",
                principalTable: "DriverLicenses",
                principalColumn: "DriverLicenseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_DriverLicenses_DriverLicenseId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_DriverLicenseId",
                table: "Persons");
        }
    }
}
