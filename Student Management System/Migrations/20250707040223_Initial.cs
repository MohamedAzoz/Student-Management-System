using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Student_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: false),
                    CourseCode = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Number_of_hours = table.Column<int>(type: "int", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    SSN = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    College = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Department = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.SSN);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: false),
                    CourseId = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: false),
                    StudentId = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    EnrollmentId = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: false),
                    Value = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Enrollments_EnrollmentId",
                        column: x => x.EnrollmentId,
                        principalTable: "Enrollments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseCode", "Department", "Name", "Number_of_hours" },
                values: new object[,]
                {
                    { "#1", "En01", "Computer Science", "DataBase", 40 },
                    { "#2", "En02", "Computer Science", "C#", 40 },
                    { "#3", "En03", "Computer Science", "OOP", 40 },
                    { "#4", "AR01", "English Literature", "Lisning", 45 },
                    { "#5", "AR02", "English Literature", "Reading", 45 },
                    { "#6", "AR03", "English Literature", "Writing", 50 },
                    { "#7", "SC01", "Physics", "Physics", 50 },
                    { "#8", "SC02", "Physics", "Mathematics", 50 },
                    { "#9", "SC03", "Physics", "Chemistry", 50 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "SSN", "College", "DateOfBirth", "Department", "Name" },
                values: new object[,]
                {
                    { "12345678901234", "Engineering College", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer Science", "John Doe" },
                    { "23456789012345", "Arts College", new DateTime(2001, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "English Literature", "Jane Smith" },
                    { "34567890123456", "Science College", new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Physics", "Alice Johnson" }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "CourseId", "EnrollmentDate", "StudentId" },
                values: new object[,]
                {
                    { "#1234", "#6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "23456789012345" },
                    { "#1245", "#7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "34567890123456" },
                    { "#1454", "#4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "23456789012345" },
                    { "#2454", "#3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12345678901234" },
                    { "#7845", "#9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "34567890123456" },
                    { "#7994", "#1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12345678901234" },
                    { "#8541", "#5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "23456789012345" },
                    { "#9451", "#2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12345678901234" },
                    { "#9884", "#8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "34567890123456" }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "EnrollmentId", "Value" },
                values: new object[,]
                {
                    { 1, "#7994", 85.5m },
                    { 2, "#9451", 90m },
                    { 3, "#2454", 78m },
                    { 4, "#1454", 82m },
                    { 5, "#8541", 87.5m },
                    { 6, "#1234", 79m },
                    { 7, "#1245", 88m },
                    { 8, "#9884", 85m },
                    { 9, "#7845", 90m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_EnrollmentId",
                table: "Grades",
                column: "EnrollmentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
