﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace RoShop.Migrations
{
    public partial class addConfirmPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "User");
        }
    }
}
