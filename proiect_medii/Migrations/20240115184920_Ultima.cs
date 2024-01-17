using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proiect_medii.Migrations
{
    public partial class Ultima : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nume_termianale",
                table: "Terminal",
                newName: "Nume_terminal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nume_terminal",
                table: "Terminal",
                newName: "Nume_termianale");
        }
    }
}
