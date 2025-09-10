namespace course_learning_tutorial.Data.Models;
public class Lesson
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
}