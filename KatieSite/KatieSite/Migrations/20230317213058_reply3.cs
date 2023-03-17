using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KatieSite.Migrations
{
    public partial class reply3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumPosts_ForumPosts_ReplyPostId",
                table: "ForumPosts");

            migrationBuilder.DropColumn(
                name: "IsReply",
                table: "ForumPosts");

            migrationBuilder.RenameColumn(
                name: "ReplyPostId",
                table: "ForumPosts",
                newName: "ForumPostPostId");

            migrationBuilder.RenameIndex(
                name: "IX_ForumPosts_ReplyPostId",
                table: "ForumPosts",
                newName: "IX_ForumPosts_ForumPostPostId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "ForumPosts",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPosts_ForumPosts_ForumPostPostId",
                table: "ForumPosts",
                column: "ForumPostPostId",
                principalTable: "ForumPosts",
                principalColumn: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumPosts_ForumPosts_ForumPostPostId",
                table: "ForumPosts");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "ForumPosts");

            migrationBuilder.RenameColumn(
                name: "ForumPostPostId",
                table: "ForumPosts",
                newName: "ReplyPostId");

            migrationBuilder.RenameIndex(
                name: "IX_ForumPosts_ForumPostPostId",
                table: "ForumPosts",
                newName: "IX_ForumPosts_ReplyPostId");

            migrationBuilder.AddColumn<bool>(
                name: "IsReply",
                table: "ForumPosts",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPosts_ForumPosts_ReplyPostId",
                table: "ForumPosts",
                column: "ReplyPostId",
                principalTable: "ForumPosts",
                principalColumn: "PostId");
        }
    }
}
