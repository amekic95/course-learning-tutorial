namespace course_learning_tutorial.Data.Models;
public class Author
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Course> Courses { get; set; } = new List<Course>();
}