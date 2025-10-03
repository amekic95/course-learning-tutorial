using course_learning_tutorial.Data.DTOs;
using course_learning_tutorial.Data.Models;

namespace course_learning_tutorial.Services;

public interface ICourseService
{
    Task<IEnumerable<CourseDto>> GetCoursesAsync(string? authorName = null, CancellationToken ct = default);
    Task<CourseDto?> GetCourseByIdAsync(int id);
    Task<int> AddCourseAsync(CreateCourseRequest request, CancellationToken ct = default);
    Task UpdateCourseAsync(CourseDto course);
    Task DeleteCourseAsync(int id);
}