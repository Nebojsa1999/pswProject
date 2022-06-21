using Microsoft.EntityFrameworkCore.Migrations;

namespace PSWProjekat.Migrations
{
    public partial class AddedFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Pharmacys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Pharmacys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Producer",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "countryProducer",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "note",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Hospitals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Hospitals",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Pharmacys");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Pharmacys");

            migrationBuilder.DropColumn(
                name: "Producer",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "countryProducer",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "note",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Hospitals");
        }
    }
}
