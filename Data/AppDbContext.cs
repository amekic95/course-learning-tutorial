using Microsoft.EntityFrameworkCore;
using course_learning_tutorial.Data.Models;

namespace course_learning_tutorial.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<CourseStudent> CourseStudents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        // Seed Authors
        modelBuilder.Entity<Author>().HasData(
            new Author { Id = 1, Name = "Jane Doe" },
            new Author { Id = 2, Name = "John Smith" },
            new Author { Id = 3, Name = "Emily Clark" }
        );

        // Seed Courses
        modelBuilder.Entity<Course>().HasData(
            new Course { Id = 1, Name = "C# Fundamentals", AuthorId = 1 },
            new Course { Id = 2, Name = "ASP.NET Core", AuthorId = 2 },
            new Course { Id = 3, Name = "Entity Framework Core", AuthorId = 1 },
            new Course { Id = 4, Name = "LINQ Deep Dive", AuthorId = 3 }
        );

        // Seed Lessons
        modelBuilder.Entity<Lesson>().HasData(
            new Lesson { Id = 1, Title = "Introduction", CourseId = 1 },
            new Lesson { Id = 2, Title = "OOP Concepts", CourseId = 1 },
            new Lesson { Id = 3, Title = "Controllers", CourseId = 2 },
            new Lesson { Id = 4, Title = "DbContext Basics", CourseId = 3 },
            new Lesson { Id = 5, Title = "LINQ Queries", CourseId = 4 },
            new Lesson { Id = 6, Title = "Advanced LINQ", CourseId = 4 }
        );

        // Seed Students
        modelBuilder.Entity<Student>().HasData(
            new Student { Id = 1, Name = "Alice" },
            new Student { Id = 2, Name = "Bob" },
            new Student { Id = 3, Name = "Charlie" },
            new Student { Id = 4, Name = "Diana" }
        );

        // Seed CourseStudent (many-to-many)
        modelBuilder.Entity<CourseStudent>().HasData(
            new CourseStudent { CourseId = 1, StudentId = 1 },
            new CourseStudent { CourseId = 1, StudentId = 2 },
            new CourseStudent { CourseId = 2, StudentId = 2 },
            new CourseStudent { CourseId = 2, StudentId = 3 },
            new CourseStudent { CourseId = 3, StudentId = 1 },
            new CourseStudent { CourseId = 3, StudentId = 4 },
            new CourseStudent { CourseId = 4, StudentId = 3 },
            new CourseStudent { CourseId = 4, StudentId = 4 }
        );
    }
}