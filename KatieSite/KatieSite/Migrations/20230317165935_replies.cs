using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KatieSite.Migrations
{
    public partial class replies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReplyPostId",
                table: "ForumPosts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ForumPosts_ReplyPostId",
                table: "ForumPosts",
                column: "ReplyPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPosts_ForumPosts_ReplyPostId",
                table: "ForumPosts",
                column: "ReplyPostId",
                principalTable: "ForumPosts",
                principalColumn: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumPosts_ForumPosts_ReplyPostId",
                table: "ForumPosts");

            migrationBuilder.DropIndex(
                name: "IX_ForumPosts_ReplyPostId",
                table: "ForumPosts");

            migrationBuilder.DropColumn(
                name: "ReplyPostId",
                table: "ForumPosts");
        }
    }
}
