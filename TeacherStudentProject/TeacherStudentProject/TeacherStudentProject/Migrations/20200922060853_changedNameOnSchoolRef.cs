using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherStudentProject.Migrations
{
    public partial class changedNameOnSchoolRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Schools_SchoolId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_SchoolId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "Teachers");

            migrationBuilder.AddColumn<int>(
                name: "SchoolRefId",
                table: "Teachers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_SchoolRefId",
                table: "Teachers",
                column: "SchoolRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Schools_SchoolRefId",
                table: "Teachers",
                column: "SchoolRefId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Schools_SchoolRefId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_SchoolRefId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "SchoolRefId",
                table: "Teachers");

            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_SchoolId",
                table: "Teachers",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Schools_SchoolId",
                table: "Teachers",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
