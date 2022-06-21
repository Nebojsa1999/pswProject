using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PSWProjekat.Migrations
{
    public partial class addedFieldsInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CancelCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDateOfCancel",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "PotentialSpammer",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CancelCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastDateOfCancel",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PotentialSpammer",
                table: "Users");
        }
    }
}
