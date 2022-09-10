using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Console.EF.Migrations
{
    public partial class AddNewFieldGitHubInTableUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GitHub",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GitHub",
                table: "Users");
        }
    }
}
