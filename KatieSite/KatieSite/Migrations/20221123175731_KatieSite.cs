using Microsoft.EntityFrameworkCore.Migrations;

namespace KatieSite.Migrations
{
    public partial class KatieSite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumPosts_Rating_ratingId",
                table: "ForumPosts");

            migrationBuilder.RenameColumn(
                name: "user",
                table: "ForumPosts",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "ratingId",
                table: "ForumPosts",
                newName: "RatingId");

            migrationBuilder.RenameColumn(
                name: "head",
                table: "ForumPosts",
                newName: "Head");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "ForumPosts",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "body",
                table: "ForumPosts",
                newName: "Body");

            migrationBuilder.RenameIndex(
                name: "IX_ForumPosts_ratingId",
                table: "ForumPosts",
                newName: "IX_ForumPosts_RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPosts_Rating_RatingId",
                table: "ForumPosts",
                column: "RatingId",
                principalTable: "Rating",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumPosts_Rating_RatingId",
                table: "ForumPosts");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "ForumPosts",
                newName: "user");

            migrationBuilder.RenameColumn(
                name: "RatingId",
                table: "ForumPosts",
                newName: "ratingId");

            migrationBuilder.RenameColumn(
                name: "Head",
                table: "ForumPosts",
                newName: "head");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "ForumPosts",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Body",
                table: "ForumPosts",
                newName: "body");

            migrationBuilder.RenameIndex(
                name: "IX_ForumPosts_RatingId",
                table: "ForumPosts",
                newName: "IX_ForumPosts_ratingId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPosts_Rating_ratingId",
                table: "ForumPosts",
                column: "ratingId",
                principalTable: "Rating",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
