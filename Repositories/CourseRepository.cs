using course_learning_tutorial.Data;
using course_learning_tutorial.Data.Models;
using Microsoft.EntityFrameworkCore;


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
        var courses = await _context.Courses
            .Include(c => c.Author)
            .Include(c => c.Lessons)
            .Include(c => c.CourseStudents)
                .ThenInclude(cs => cs.Student)
            .ToListAsync();
        return courses;
    }

    public async Task<Course?> GetByIdAsync(int id, CancellationToken ct = default)
    {

        var course = await _context.Courses
            .AsNoTracking()
            .Include(c => c.Author)
            .Include(c => c.Lessons)
            .Include(c => c.CourseStudents).ThenInclude(cs => cs.Student)
            .AsSplitQuery()
            .FirstOrDefaultAsync(c => c.Id == id, ct);

        return course;
    }

    public async Task<IEnumerable<Course>> GetByAuthorNameAsync(string authorName, CancellationToken ct = default)
    {
        return await _context.Courses
            .Include(c => c.Author)
            .Include(c => c.Lessons)
            .Include(c => c.CourseStudents).ThenInclude(cs => cs.Student)
            .Where(c => c.Author.Name == authorName)
            .ToListAsync(ct);
    }
    public async Task AddAsync(Course course, CancellationToken ct = default)
    {
        _context.Courses.Add(course);
        await _context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Course course, CancellationToken ct = default)
    {
        _context.Courses.Update(course);
        await _context.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course != null)
        {
            await _context.SaveChangesAsync();
        }
    }
}