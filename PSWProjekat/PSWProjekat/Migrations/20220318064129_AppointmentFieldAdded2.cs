using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PSWProjekat.Migrations
{
    public partial class AppointmentFieldAdded2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_UserId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "AppointmentTimeEnd",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "AppointmentTimeStart",
                table: "Appointments",
                newName: "AppointmentDate");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Examinations",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "AppointmentTime",
                table: "Appointments",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_UserId",
                table: "Examinations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_Users_UserId",
                table: "Examinations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_Users_UserId",
                table: "Examinations");

            migrationBuilder.DropIndex(
                name: "IX_Examinations_UserId",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "AppointmentTime",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "AppointmentDate",
                table: "Appointments",
                newName: "AppointmentTimeStart");

            migrationBuilder.AddColumn<DateTime>(
                name: "AppointmentTimeEnd",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Appointments",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_UserId",
                table: "Appointments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
