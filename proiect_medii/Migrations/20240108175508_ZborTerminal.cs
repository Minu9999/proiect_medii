using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proiect_medii.Migrations
{
    public partial class ZborTerminal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanieID",
                table: "Zbor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Companie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume_companie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Terminal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume_termianale = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminal", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ZborTerminal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZborID = table.Column<int>(type: "int", nullable: false),
                    TerminalID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZborTerminal", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ZborTerminal_Terminal_TerminalID",
                        column: x => x.TerminalID,
                        principalTable: "Terminal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZborTerminal_Zbor_ZborID",
                        column: x => x.ZborID,
                        principalTable: "Zbor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zbor_CompanieID",
                table: "Zbor",
                column: "CompanieID");

            migrationBuilder.CreateIndex(
                name: "IX_ZborTerminal_TerminalID",
                table: "ZborTerminal",
                column: "TerminalID");

            migrationBuilder.CreateIndex(
                name: "IX_ZborTerminal_ZborID",
                table: "ZborTerminal",
                column: "ZborID");

            migrationBuilder.AddForeignKey(
                name: "FK_Zbor_Companie_CompanieID",
                table: "Zbor",
                column: "CompanieID",
                principalTable: "Companie",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zbor_Companie_CompanieID",
                table: "Zbor");

            migrationBuilder.DropTable(
                name: "Companie");

            migrationBuilder.DropTable(
                name: "ZborTerminal");

            migrationBuilder.DropTable(
                name: "Terminal");

            migrationBuilder.DropIndex(
                name: "IX_Zbor_CompanieID",
                table: "Zbor");

            migrationBuilder.DropColumn(
                name: "CompanieID",
                table: "Zbor");
        }
    }
}
