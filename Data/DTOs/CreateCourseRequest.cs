namespace course_learning_tutorial.Data.DTOs;
public class CreateCourseRequest
{
    public string Name { get; set; } = null!;
    public int AuthorId { get; set; }
    public List<string>? LessonTitles { get; set; }
    public List<int>? StudentIds { get; set; }
}
