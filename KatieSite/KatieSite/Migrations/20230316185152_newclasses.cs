using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KatieSite.Migrations
{
    public partial class newclasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "ForumPosts");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "ForumPosts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RpgBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Published = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PublishedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RpgBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RpgBooks_Publishers_PublishedById",
                        column: x => x.PublishedById,
                        principalTable: "Publishers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ForumPosts_BookId",
                table: "ForumPosts",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_RpgBooks_PublishedById",
                table: "RpgBooks",
                column: "PublishedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPosts_RpgBooks_BookId",
                table: "ForumPosts",
                column: "BookId",
                principalTable: "RpgBooks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumPosts_RpgBooks_BookId",
                table: "ForumPosts");

            migrationBuilder.DropTable(
                name: "RpgBooks");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropIndex(
                name: "IX_ForumPosts_BookId",
                table: "ForumPosts");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "ForumPosts");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "ForumPosts",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
