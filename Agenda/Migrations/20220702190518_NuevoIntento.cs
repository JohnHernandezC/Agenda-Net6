using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agenda.Migrations
{
    public partial class NuevoIntento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacto_categoria_categoriasId",
                table: "contacto");

            migrationBuilder.DropIndex(
                name: "IX_contacto_categoriasId",
                table: "contacto");

            migrationBuilder.DropColumn(
                name: "categoriasId",
                table: "contacto");

            migrationBuilder.CreateIndex(
                name: "IX_contacto_categoriaId",
                table: "contacto",
                column: "categoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_contacto_categoria_categoriaId",
                table: "contacto",
                column: "categoriaId",
                principalTable: "categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacto_categoria_categoriaId",
                table: "contacto");

            migrationBuilder.DropIndex(
                name: "IX_contacto_categoriaId",
                table: "contacto");

            migrationBuilder.AddColumn<int>(
                name: "categoriasId",
                table: "contacto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_contacto_categoriasId",
                table: "contacto",
                column: "categoriasId");

            migrationBuilder.AddForeignKey(
                name: "FK_contacto_categoria_categoriasId",
                table: "contacto",
                column: "categoriasId",
                principalTable: "categoria",
                principalColumn: "Id");
        }
    }
}
