namespace course_learning_tutorial.Data.DTOs;

public class CourseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int AuthorId { get; set; }
    public string AuthorName { get; set; }
    public List<LessonDto> Lessons { get; set; }
    public List<StudentDto> Students { get; set; }
} 