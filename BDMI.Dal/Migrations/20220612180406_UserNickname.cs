﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDMI.Web.Data.Migrations
{
    public partial class UserNickname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "AspNetUsers");
        }
    }
}
