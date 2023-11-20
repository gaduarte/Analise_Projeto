using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace biblioteca_trabalho.Migrations
{
    public partial class QuartaParte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avaliacoes",
                table: "RefrenceBooks",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Citacoes",
                table: "RefrenceBooks",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Preco",
                table: "RefrenceBooks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "GeneralBooks",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Edicao",
                table: "GeneralBooks",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avaliacoes",
                table: "RefrenceBooks");

            migrationBuilder.DropColumn(
                name: "Citacoes",
                table: "RefrenceBooks");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "RefrenceBooks");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "GeneralBooks");

            migrationBuilder.DropColumn(
                name: "Edicao",
                table: "GeneralBooks");
        }
    }
}
