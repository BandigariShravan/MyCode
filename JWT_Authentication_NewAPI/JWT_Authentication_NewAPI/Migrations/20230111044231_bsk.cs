using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWTAuthenticationNewAPI.Migrations
{
    /// <inheritdoc />
    public partial class bsk : Migration
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
                    table.PrimaryKey("PK_AuthenticationResponses", x => x.Token);
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
                    table.PrimaryKey("PK_LoginCredentials", x => x.UserName);
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
                    table.PrimaryKey("PK_students", x => x.StudentId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthenticationResponses1");

            migrationBuilder.DropTable(
                name: "LoginCredentials1");

            migrationBuilder.DropTable(
                name: "students1");
        }
    }
}
