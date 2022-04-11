using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RoShop.Migrations
{
    public partial class addProductFiletable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdProduct",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductFileId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DataFiles = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFile", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductFileId",
                table: "Product",
                column: "ProductFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductFile_ProductFileId",
                table: "Product",
                column: "ProductFileId",
                principalTable: "ProductFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductFile_ProductFileId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "ProductFile");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductFileId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IdProduct",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductFileId",
                table: "Product");
        }
    }
}
