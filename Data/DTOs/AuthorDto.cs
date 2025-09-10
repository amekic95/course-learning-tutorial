namespace course_learning_tutorial.Data.DTOs;

public class AuthorDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<CourseDto> Courses { get; set; }
}