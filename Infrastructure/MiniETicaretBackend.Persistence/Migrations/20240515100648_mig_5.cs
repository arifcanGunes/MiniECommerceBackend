﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniETicaretBackend.Persistence.Migrations
{
    public partial class mig_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Storage",
                table: "Files",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Storage",
                table: "Files");
        }
    }
}
