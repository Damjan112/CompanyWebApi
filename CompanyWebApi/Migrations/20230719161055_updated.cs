using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyWebApi.Migrations
{
    /// <inheritdoc />
    public partial class updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacts_companies_CompanyId",
                table: "contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_contacts_countries_CountryId",
                table: "contacts");

            migrationBuilder.DropIndex(
                name: "IX_contacts_CompanyId",
                table: "contacts");

            migrationBuilder.DropIndex(
                name: "IX_contacts_CountryId",
                table: "contacts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_contacts_CompanyId",
                table: "contacts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_CountryId",
                table: "contacts",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_companies_CompanyId",
                table: "contacts",
                column: "CompanyId",
                principalTable: "companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_countries_CountryId",
                table: "contacts",
                column: "CountryId",
                principalTable: "countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
