using Microsoft.EntityFrameworkCore.Migrations;

namespace RoShop.Migrations
{
    public partial class addIdProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdProduct",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdProduct",
                table: "Comment");
        }
    }
}
