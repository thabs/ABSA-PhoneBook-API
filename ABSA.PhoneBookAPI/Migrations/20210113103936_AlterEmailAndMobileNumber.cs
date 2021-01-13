using Microsoft.EntityFrameworkCore.Migrations;

namespace ABSA.PhoneBookAPI.Migrations
{
    public partial class AlterEmailAndMobileNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Email_MobileNumber",
                table: "Contacts",
                columns: new[] { "Email", "MobileNumber" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contacts_Email_MobileNumber",
                table: "Contacts");
        }
    }
}
