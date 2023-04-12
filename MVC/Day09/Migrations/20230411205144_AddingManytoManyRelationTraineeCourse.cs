using Microsoft.EntityFrameworkCore.Migrations;

namespace Day09_remake.Migrations
{
    public partial class AddingManytoManyRelationTraineeCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseTrainee");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Courses");

            migrationBuilder.CreateTable(
                name: "TraineesCourses",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    TraineeID = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraineesCourses", x => new { x.TraineeID, x.CourseID });
                    table.ForeignKey(
                        name: "FK_TraineesCourses_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TraineesCourses_Trainees_TraineeID",
                        column: x => x.TraineeID,
                        principalTable: "Trainees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TraineesCourses_CourseID",
                table: "TraineesCourses",
                column: "CourseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TraineesCourses");

            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CourseTrainee",
                columns: table => new
                {
                    CoursesID = table.Column<int>(type: "int", nullable: false),
                    TraineesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTrainee", x => new { x.CoursesID, x.TraineesID });
                    table.ForeignKey(
                        name: "FK_CourseTrainee_Courses_CoursesID",
                        column: x => x.CoursesID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseTrainee_Trainees_TraineesID",
                        column: x => x.TraineesID,
                        principalTable: "Trainees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseTrainee_TraineesID",
                table: "CourseTrainee",
                column: "TraineesID");
        }
    }
}
