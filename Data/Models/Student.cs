namespace course_learning_tutorial.Data.Models;
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<CourseStudent> CourseStudents { get; set; }
}