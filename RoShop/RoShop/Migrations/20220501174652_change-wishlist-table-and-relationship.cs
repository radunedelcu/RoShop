using Microsoft.EntityFrameworkCore.Migrations;

namespace RoShop.Migrations
{
    public partial class changewishlisttableandrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_UserWishlistProduct_UserWishlistProductIdUserWishlistProduct",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWishlistProduct_User_UserId",
                table: "UserWishlistProduct");

            migrationBuilder.DropIndex(
                name: "IX_Product_UserWishlistProductIdUserWishlistProduct",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IdUserWishlistProduct",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UserWishlistProductIdUserWishlistProduct",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "UserWishlistProduct",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserWishlistProduct_ProductId",
                table: "UserWishlistProduct",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserWishlistProduct_Product_ProductId",
                table: "UserWishlistProduct",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWishlistProduct_User_UserId",
                table: "UserWishlistProduct",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWishlistProduct_Product_ProductId",
                table: "UserWishlistProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWishlistProduct_User_UserId",
                table: "UserWishlistProduct");

            migrationBuilder.DropIndex(
                name: "IX_UserWishlistProduct_ProductId",
                table: "UserWishlistProduct");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "UserWishlistProduct");

            migrationBuilder.AddColumn<int>(
                name: "IdUserWishlistProduct",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserWishlistProductIdUserWishlistProduct",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_UserWishlistProductIdUserWishlistProduct",
                table: "Product",
                column: "UserWishlistProductIdUserWishlistProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_UserWishlistProduct_UserWishlistProductIdUserWishlistProduct",
                table: "Product",
                column: "UserWishlistProductIdUserWishlistProduct",
                principalTable: "UserWishlistProduct",
                principalColumn: "IdUserWishlistProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_UserWishlistProduct_User_UserId",
                table: "UserWishlistProduct",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
