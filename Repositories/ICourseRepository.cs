using course_learning_tutorial.Data.Models;

namespace course_learning_tutorial.Repositories;

public interface ICourseRepository
{
    Task<IEnumerable<Course>> GetAllAsync();
    Task<Course?> GetByIdAsync(int id, CancellationToken ct = default);
    Task AddAsync(Course course, CancellationToken ct = default);
    Task UpdateAsync(Course course, CancellationToken ct = default);
    Task DeleteAsync(int id);
}