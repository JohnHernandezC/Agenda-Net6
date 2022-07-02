using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agenda.Migrations
{
    public partial class Errores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contactos_categoria_categoriasId",
                table: "contactos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contactos",
                table: "contactos");

            migrationBuilder.RenameTable(
                name: "contactos",
                newName: "contacto");

            migrationBuilder.RenameIndex(
                name: "IX_contactos_categoriasId",
                table: "contacto",
                newName: "IX_contacto_categoriasId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contacto",
                table: "contacto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_contacto_categoria_categoriasId",
                table: "contacto",
                column: "categoriasId",
                principalTable: "categoria",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacto_categoria_categoriasId",
                table: "contacto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contacto",
                table: "contacto");

            migrationBuilder.RenameTable(
                name: "contacto",
                newName: "contactos");

            migrationBuilder.RenameIndex(
                name: "IX_contacto_categoriasId",
                table: "contactos",
                newName: "IX_contactos_categoriasId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contactos",
                table: "contactos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_contactos_categoria_categoriasId",
                table: "contactos",
                column: "categoriasId",
                principalTable: "categoria",
                principalColumn: "Id");
        }
    }
}
