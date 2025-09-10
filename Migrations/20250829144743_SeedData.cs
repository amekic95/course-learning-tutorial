using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace course_learning_tutorial.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Jane Doe" },
                    { 2, "John Smith" },
                    { 3, "Emily Clark" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Alice" },
                    { 2, "Bob" },
                    { 3, "Charlie" },
                    { 4, "Diana" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "AuthorId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "C# Fundamentals" },
                    { 2, 2, "ASP.NET Core" },
                    { 3, 1, "Entity Framework Core" },
                    { 4, 3, "LINQ Deep Dive" }
                });

            migrationBuilder.InsertData(
                table: "CourseStudents",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 1 },
                    { 3, 4 },
                    { 4, 3 },
                    { 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CourseId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Introduction" },
                    { 2, 1, "OOP Concepts" },
                    { 3, 2, "Controllers" },
                    { 4, 3, "DbContext Basics" },
                    { 5, 4, "LINQ Queries" },
                    { 6, 4, "Advanced LINQ" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
