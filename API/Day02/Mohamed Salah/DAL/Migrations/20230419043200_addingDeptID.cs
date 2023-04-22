using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class addingDeptID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Departments_DepartmentId",
                table: "Instructors");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Instructors",
                newName: "DepartmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Instructors_DepartmentId",
                table: "Instructors",
                newName: "IX_Instructors_DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Departments_DepartmentID",
                table: "Instructors",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Departments_DepartmentID",
                table: "Instructors");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "Instructors",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Instructors_DepartmentID",
                table: "Instructors",
                newName: "IX_Instructors_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Departments_DepartmentId",
                table: "Instructors",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
