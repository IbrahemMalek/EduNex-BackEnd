using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduNexDB.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentsAnswersSubmissionsFKs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StudentsAnswersSubmissions_AnswerId",
                table: "StudentsAnswersSubmissions",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsAnswersSubmissions_ExamId",
                table: "StudentsAnswersSubmissions",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsAnswersSubmissions_QuestionId",
                table: "StudentsAnswersSubmissions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsAnswersSubmissions_StudentId",
                table: "StudentsAnswersSubmissions",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsAnswersSubmissions_Answers_AnswerId",
                table: "StudentsAnswersSubmissions",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "AnswerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsAnswersSubmissions_Exams_ExamId",
                table: "StudentsAnswersSubmissions",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "ExamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsAnswersSubmissions_Questions_QuestionId",
                table: "StudentsAnswersSubmissions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsAnswersSubmissions_Student_StudentId",
                table: "StudentsAnswersSubmissions",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsAnswersSubmissions_Answers_AnswerId",
                table: "StudentsAnswersSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsAnswersSubmissions_Exams_ExamId",
                table: "StudentsAnswersSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsAnswersSubmissions_Questions_QuestionId",
                table: "StudentsAnswersSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsAnswersSubmissions_Student_StudentId",
                table: "StudentsAnswersSubmissions");

            migrationBuilder.DropIndex(
                name: "IX_StudentsAnswersSubmissions_AnswerId",
                table: "StudentsAnswersSubmissions");

            migrationBuilder.DropIndex(
                name: "IX_StudentsAnswersSubmissions_ExamId",
                table: "StudentsAnswersSubmissions");

            migrationBuilder.DropIndex(
                name: "IX_StudentsAnswersSubmissions_QuestionId",
                table: "StudentsAnswersSubmissions");

            migrationBuilder.DropIndex(
                name: "IX_StudentsAnswersSubmissions_StudentId",
                table: "StudentsAnswersSubmissions");
        }
    }
}
