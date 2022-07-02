using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agenda.Migrations
{
    public partial class DosLlaves : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "riesgoId",
                table: "contacto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "riesgos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_riesgos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contacto_riesgoId",
                table: "contacto",
                column: "riesgoId");

            migrationBuilder.AddForeignKey(
                name: "FK_contacto_riesgos_riesgoId",
                table: "contacto",
                column: "riesgoId",
                principalTable: "riesgos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacto_riesgos_riesgoId",
                table: "contacto");

            migrationBuilder.DropTable(
                name: "riesgos");

            migrationBuilder.DropIndex(
                name: "IX_contacto_riesgoId",
                table: "contacto");

            migrationBuilder.DropColumn(
                name: "riesgoId",
                table: "contacto");
        }
    }
}
