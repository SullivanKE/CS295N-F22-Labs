using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KatieSite.Migrations
{
    public partial class reply2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReply",
                table: "ForumPosts",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReply",
                table: "ForumPosts");
        }
    }
}
