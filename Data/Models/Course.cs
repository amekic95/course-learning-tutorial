namespace course_learning_tutorial.Data.Models;
public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;
    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    public ICollection<CourseStudent> CourseStudents { get; set; } = new List<CourseStudent>();
}