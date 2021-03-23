using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherStudentProject.Migrations
{
    public partial class schoolIdPropertyAddedtoTeacheclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Schools_SchoolsId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_SchoolsId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "SchoolsId",
                table: "Teachers");

            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "Teachers",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "SchoolsId",
                table: "Teachers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_SchoolsId",
                table: "Teachers",
                column: "SchoolsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Schools_SchoolsId",
                table: "Teachers",
                column: "SchoolsId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
