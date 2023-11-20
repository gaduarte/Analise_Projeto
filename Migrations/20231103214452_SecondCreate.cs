using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace biblioteca_trabalho.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Librarians_Alert_AlertId",
                table: "Librarians");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alert",
                table: "Alert");

            migrationBuilder.RenameTable(
                name: "Alert",
                newName: "Alerts");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Members",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FacultyColl",
                table: "Members",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Fname",
                table: "Members",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Sname",
                table: "Members",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "StudentColl",
                table: "Members",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Books",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alerts",
                table: "Alerts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Librarians_Alerts_AlertId",
                table: "Librarians",
                column: "AlertId",
                principalTable: "Alerts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Librarians_Alerts_AlertId",
                table: "Librarians");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alerts",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "FacultyColl",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Fname",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Sname",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "StudentColl",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Alerts",
                newName: "Alert");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alert",
                table: "Alert",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Librarians_Alert_AlertId",
                table: "Librarians",
                column: "AlertId",
                principalTable: "Alert",
                principalColumn: "Id");
        }
    }
}
