using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PSWProjekat.Migrations
{
    public partial class updatedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Users_UserPatientId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Medicines_MedicineId",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Users_PatientUserId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_MedicineId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_PatientUserId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_UserPatientId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "MedicineId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "PatientUserId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "UserPatientId",
                table: "Feedbacks");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfCreation",
                table: "Prescriptions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Doctor",
                table: "Prescriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientUser",
                table: "Prescriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PrescriptionMedicine",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineId = table.Column<long>(type: "bigint", nullable: true),
                    PrescriptionId = table.Column<long>(type: "bigint", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionMedicine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrescriptionMedicine_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrescriptionMedicine_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicine_MedicineId",
                table: "PrescriptionMedicine",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicine_PrescriptionId",
                table: "PrescriptionMedicine",
                column: "PrescriptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrescriptionMedicine");

            migrationBuilder.DropColumn(
                name: "DateOfCreation",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "Doctor",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "PatientUser",
                table: "Prescriptions");

            migrationBuilder.AddColumn<long>(
                name: "MedicineId",
                table: "Prescriptions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PatientUserId",
                table: "Prescriptions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "UserPatientId",
                table: "Feedbacks",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_MedicineId",
                table: "Prescriptions",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientUserId",
                table: "Prescriptions",
                column: "PatientUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UserPatientId",
                table: "Feedbacks",
                column: "UserPatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Users_UserPatientId",
                table: "Feedbacks",
                column: "UserPatientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Medicines_MedicineId",
                table: "Prescriptions",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Users_PatientUserId",
                table: "Prescriptions",
                column: "PatientUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
