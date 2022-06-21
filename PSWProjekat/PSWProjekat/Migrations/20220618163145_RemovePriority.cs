using Microsoft.EntityFrameworkCore.Migrations;

namespace PSWProjekat.Migrations
{
    public partial class RemovePriority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Appointments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Priority",
                table: "Appointments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
