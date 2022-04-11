using Microsoft.EntityFrameworkCore.Migrations;

namespace RoShop.Migrations
{
    public partial class addIdProductFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdProduct",
                table: "Product",
                newName: "IdProductFile");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdProductFile",
                table: "Product",
                newName: "IdProduct");
        }
    }
}
