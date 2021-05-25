using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCarsProject.Migrations
{
    public partial class removeViewCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Cars");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Cars",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
