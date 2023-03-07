using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWTAuthenticationNewAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingEnrollmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthenticationResponses1",
                columns: table => new
                {
                    Token = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationResponses1", x => x.Token);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(name: "Course_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(name: "Course_Name", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "LoginCredentials1",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginCredentials1", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "students1",
                columns: table => new
                {
                    StudentId = table.Column<int>(name: "Student_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(name: "Student_Name", type: "nvarchar(max)", nullable: false),
                    StudentEmail = table.Column<string>(name: "Student_Email", type: "nvarchar(max)", nullable: false),
                    StudentPhone = table.Column<string>(name: "Student_Phone", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students1", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments1",
                columns: table => new
                {
                    EnrollmentId = table.Column<int>(name: "Enrollment_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(name: "Student_Id", type: "int", nullable: false),
                    CourseId = table.Column<int>(name: "Course_Id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments1", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_Enrollments1_Course_Course_Id",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Course_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments1_students1_Student_Id",
                        column: x => x.StudentId,
                        principalTable: "students1",
                        principalColumn: "Student_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments1_Course_Id",
                table: "Enrollments1",
                column: "Course_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments1_Student_Id",
                table: "Enrollments1",
                column: "Student_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthenticationResponses1");

            migrationBuilder.DropTable(
                name: "Enrollments1");

            migrationBuilder.DropTable(
                name: "LoginCredentials1");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "students1");
        }
    }
}
