using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace biblioteca_trabalho.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Alert",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IssueDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BookName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReturnDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Fine = table.Column<int>(type: "int", nullable: true),
                    LibrarianId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alert", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Catalogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AuthorName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NoofCopies = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Mname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Maddress = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mno = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Librarians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Adrdress = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mobileno = table.Column<int>(type: "int", nullable: true),
                    AlertId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Librarians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Librarians_Alert_AlertId",
                        column: x => x.AlertId,
                        principalTable: "Alert",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AuthorName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BookName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NoofBooks = table.Column<int>(type: "int", nullable: false),
                    CatalogId = table.Column<int>(type: "int", nullable: true),
                    MemberId = table.Column<int>(type: "int", nullable: true),
                    Librarian1Id = table.Column<int>(type: "int", nullable: true),
                    Librarian2Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Catalogs_CatalogId",
                        column: x => x.CatalogId,
                        principalTable: "Catalogs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Books_Librarians_Librarian1Id",
                        column: x => x.Librarian1Id,
                        principalTable: "Librarians",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Books_Librarians_Librarian2Id",
                        column: x => x.Librarian2Id,
                        principalTable: "Librarians",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Books_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LibrarianMember",
                columns: table => new
                {
                    LibrariansId = table.Column<int>(type: "int", nullable: false),
                    MembersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibrarianMember", x => new { x.LibrariansId, x.MembersId });
                    table.ForeignKey(
                        name: "FK_LibrarianMember_Librarians_LibrariansId",
                        column: x => x.LibrariansId,
                        principalTable: "Librarians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibrarianMember_Members_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CatalogId",
                table: "Books",
                column: "CatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Librarian1Id",
                table: "Books",
                column: "Librarian1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Librarian2Id",
                table: "Books",
                column: "Librarian2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Books_MemberId",
                table: "Books",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_LibrarianMember_MembersId",
                table: "LibrarianMember",
                column: "MembersId");

            migrationBuilder.CreateIndex(
                name: "IX_Librarians_AlertId",
                table: "Librarians",
                column: "AlertId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "LibrarianMember");

            migrationBuilder.DropTable(
                name: "Catalogs");

            migrationBuilder.DropTable(
                name: "Librarians");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Alert");
        }
    }
}
