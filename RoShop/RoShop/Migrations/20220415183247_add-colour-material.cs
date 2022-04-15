using Microsoft.EntityFrameworkCore.Migrations;

namespace RoShop.Migrations
{
    public partial class addcolourmaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Colour",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Material",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Colour",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Material",
                table: "Product");
        }
    }
}
