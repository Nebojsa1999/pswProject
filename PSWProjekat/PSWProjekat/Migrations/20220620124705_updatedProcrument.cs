using Microsoft.EntityFrameworkCore.Migrations;

namespace PSWProjekat.Migrations
{
    public partial class updatedProcrument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Hospitals_HospitalId",
                table: "Medicines");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_HospitalId",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "HospitalId",
                table: "Medicines");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Procurements",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Procurements");

            migrationBuilder.AddColumn<long>(
                name: "HospitalId",
                table: "Medicines",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_HospitalId",
                table: "Medicines",
                column: "HospitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Hospitals_HospitalId",
                table: "Medicines",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
