using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotNETBlog.Migrations
{
    public partial class macOsMigrationsNo4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nick",
                table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nick",
                table: "Categories",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
