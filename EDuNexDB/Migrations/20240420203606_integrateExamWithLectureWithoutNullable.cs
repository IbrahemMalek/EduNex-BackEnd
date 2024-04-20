using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduNexDB.Migrations
{
    /// <inheritdoc />
    public partial class integrateExamWithLectureWithoutNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Lecture_LectureId",
                table: "Exams");

            migrationBuilder.AlterColumn<int>(
                name: "LectureId",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Lecture_LectureId",
                table: "Exams",
                column: "LectureId",
                principalTable: "Lecture",
                principalColumn: "LectureId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Lecture_LectureId",
                table: "Exams");

            migrationBuilder.AlterColumn<int>(
                name: "LectureId",
                table: "Exams",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Lecture_LectureId",
                table: "Exams",
                column: "LectureId",
                principalTable: "Lecture",
                principalColumn: "LectureId");
        }
    }
}
