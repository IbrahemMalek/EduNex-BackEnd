using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduNexDB.Migrations
{
    /// <inheritdoc />
    public partial class AddMtoMStudentExam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Exams_ExamId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_ExamId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Student");

            migrationBuilder.CreateTable(
                name: "StudentExam",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Score = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentExam", x => new { x.StudentId, x.ExamId });
                    table.ForeignKey(
                        name: "FK_StudentExam_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "ExamId");
                    table.ForeignKey(
                        name: "FK_StudentExam_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentExam_ExamId",
                table: "StudentExam",
                column: "ExamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentExam");

            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ExamId",
                table: "Student",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Exams_ExamId",
                table: "Student",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "ExamId");
        }
    }
}
