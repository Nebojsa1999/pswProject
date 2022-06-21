using Microsoft.EntityFrameworkCore.Migrations;

namespace PSWProjekat.Migrations
{
    public partial class ChangedFeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsShown",
                table: "Feedbacks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShown",
                table: "Feedbacks");
        }
    }
}
