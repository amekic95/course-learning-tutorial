using course_learning_tutorial.Data;
using course_learning_tutorial.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace course_learning_tutorial.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger<CourseRepository> _logger;

    public CourseRepository(AppDbContext context, ILogger<CourseRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<Course>> GetAllAsync()
    {
        _logger.LogInformation("Retrieving all courses with related entities");

        var courses = await _context.Courses
            .Include(c => c.Author)
            .Include(c => c.Lessons)
            .Include(c => c.CourseStudents)
                .ThenInclude(cs => cs.Student)
            .ToListAsync();

        _logger.LogInformation("Retrieved {Count} courses", courses.Count);
        return courses;
    }

    public async Task<Course?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        _logger.LogInformation("Fetching course by id {CourseId}", id);

        var course = await _context.Courses
            .AsNoTracking()
            .Include(c => c.Author)
            .Include(c => c.Lessons)
            .Include(c => c.CourseStudents).ThenInclude(cs => cs.Student)
            .AsSplitQuery()
            .FirstOrDefaultAsync(c => c.Id == id, ct);

        if (course == null)
            _logger.LogWarning("Course {CourseId} not found", id);
        else
            _logger.LogInformation("Found course {CourseId}", id);

        return course;
    }

    public async Task AddAsync(Course course, CancellationToken ct = default)
    {
        _logger.LogInformation("Adding new course {Name} for author {AuthorId}", course.Name, course.AuthorId);
        _context.Courses.Add(course);
        await _context.SaveChangesAsync(ct);
        _logger.LogInformation("Added course {CourseId}", course.Id);
    }

    public async Task UpdateAsync(Course course, CancellationToken ct = default)
    {
        _logger.LogInformation("Updating course {CourseId}", course.Id);
        _context.Courses.Update(course);
        await _context.SaveChangesAsync(ct);
        _logger.LogInformation("Updated course {CourseId}", course.Id);
    }

    public async Task DeleteAsync(int id)
    {
        _logger.LogInformation("Deleting course {CourseId}", id);
        var course = await _context.Courses.FindAsync(id);
        if (course != null)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Deleted course {CourseId}", id);
        }
        else
        {
            _logger.LogWarning("Delete requested but course {CourseId} not found", id);
        }
    }
}