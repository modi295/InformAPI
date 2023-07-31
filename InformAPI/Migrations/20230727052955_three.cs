using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InformAPI.Migrations
{
    public partial class three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Registrations",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Registrations",
                newName: "Password");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Registrations",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Registrations",
                newName: "password");
        }
    }
}
