using Microsoft.EntityFrameworkCore.Migrations;

namespace PSWProjekat.Migrations
{
    public partial class ChangedRefferal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Refferals_Users_DoctorId",
                table: "Refferals");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "Refferals",
                newName: "ExaminationId");

            migrationBuilder.RenameIndex(
                name: "IX_Refferals_DoctorId",
                table: "Refferals",
                newName: "IX_Refferals_ExaminationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Refferals_Examinations_ExaminationId",
                table: "Refferals",
                column: "ExaminationId",
                principalTable: "Examinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Refferals_Examinations_ExaminationId",
                table: "Refferals");

            migrationBuilder.RenameColumn(
                name: "ExaminationId",
                table: "Refferals",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Refferals_ExaminationId",
                table: "Refferals",
                newName: "IX_Refferals_DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Refferals_Users_DoctorId",
                table: "Refferals",
                column: "DoctorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
