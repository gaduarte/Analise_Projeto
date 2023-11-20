using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace biblioteca_trabalho.Migrations
{
    public partial class TerceiroCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Librarians_Alerts_AlertId",
                table: "Librarians");

            migrationBuilder.DropIndex(
                name: "IX_Librarians_AlertId",
                table: "Librarians");

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

            migrationBuilder.CreateTable(
                name: "FacultyMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Fname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FacultyColl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacultyMember_Members_Id",
                        column: x => x.Id,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GeneralBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralBooks_Books_Id",
                        column: x => x.Id,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RefrenceBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefrenceBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefrenceBooks_Books_Id",
                        column: x => x.Id,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Sname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StudentColl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Members_Id",
                        column: x => x.Id,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_LibrarianId",
                table: "Alerts",
                column: "LibrarianId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Librarians_LibrarianId",
                table: "Alerts",
                column: "LibrarianId",
                principalTable: "Librarians",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Librarians_LibrarianId",
                table: "Alerts");

            migrationBuilder.DropTable(
                name: "FacultyMember");

            migrationBuilder.DropTable(
                name: "GeneralBooks");

            migrationBuilder.DropTable(
                name: "RefrenceBooks");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Alerts_LibrarianId",
                table: "Alerts");

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

            migrationBuilder.CreateIndex(
                name: "IX_Librarians_AlertId",
                table: "Librarians",
                column: "AlertId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Librarians_Alerts_AlertId",
                table: "Librarians",
                column: "AlertId",
                principalTable: "Alerts",
                principalColumn: "Id");
        }
    }
}
