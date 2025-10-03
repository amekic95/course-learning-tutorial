using AutoMapper;
using course_learning_tutorial.Data.DTOs;
using course_learning_tutorial.Data.Models;
using course_learning_tutorial.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace course_learning_tutorial.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<CourseService> _logger;
    public CourseService(ICourseRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = NullLogger<CourseService>.Instance;
    }

    public CourseService(ICourseRepository repository, IMapper mapper, ILogger<CourseService> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<IEnumerable<CourseDto>> GetCoursesAsync(string? authorName = null, CancellationToken ct = default)
    {
        _logger.LogInformation("Retrieving courses by author name {AuthorName}", authorName);

        var courses = authorName == null
                ? await _repository.GetAllAsync()
                : await _repository.GetByAuthorNameAsync(authorName, ct);

        var result = _mapper.Map<IEnumerable<CourseDto>>(courses);

        _logger.LogInformation("Retrieved {Count} courses by author {AuthorName}", result.Count(), authorName);
        return result;
    }

    public async Task<CourseDto?> GetCourseByIdAsync(int id)
    {
        _logger.LogInformation("Fetching course by id {CourseId}", id);
        var course = await _repository.GetByIdAsync(id);
        if (course == null)
        {
            _logger.LogWarning("Course {CourseId} not found", id);
            return null;
        }
        var dto = _mapper.Map<CourseDto>(course);
        _logger.LogInformation("Mapped course {CourseId} to DTO", id);
        return dto;
    }
    public async Task<int> AddCourseAsync(CreateCourseRequest request, CancellationToken ct = default)
    {
        _logger.LogInformation("Adding course {Name} for author {AuthorId}", request.Name, request.AuthorId);
        var course = _mapper.Map<Course>(request);

        if (request.LessonTitles?.Count > 0)
        {
            foreach (var t in request.LessonTitles.Distinct())
                course.Lessons.Add(new Lesson { Title = t });
        }

        if (request.StudentIds?.Count > 0)
        {
            foreach (var sid in request.StudentIds.Distinct())
                course.CourseStudents.Add(new CourseStudent { StudentId = sid });
        }

        await _repository.AddAsync(course, ct);
        _logger.LogInformation("Added course {CourseId}", course.Id);
        return course.Id;
    }

    public async Task UpdateCourseAsync(CourseDto courseDto)
    {
        _logger.LogInformation("Updating course {CourseId}", courseDto.Id);
        var course = _mapper.Map<Course>(courseDto);
        await _repository.UpdateAsync(course);
        _logger.LogInformation("Updated course {CourseId}", courseDto.Id);
    }

    public async Task DeleteCourseAsync(int id)
    {
        _logger.LogInformation("Deleting course {CourseId}", id);
        await _repository.DeleteAsync(id);
        _logger.LogInformation("Delete requested completed for course {CourseId}", id);
    }
}