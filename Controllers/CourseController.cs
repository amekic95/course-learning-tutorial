using course_learning_tutorial.Data.DTOs;
using course_learning_tutorial.Services;
using Microsoft.AspNetCore.Mvc;

namespace course_learning_tutorial.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourseDto>>> GetAll()
    {
        var courses = await _courseService.GetAllCoursesAsync();
        return Ok(courses);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CourseDto>> GetById(int id)
    {
        var course = await _courseService.GetCourseByIdAsync(id);
        if (course == null)
            return NotFound();
        return Ok(course);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateCourseRequest request, CancellationToken ct)
    {
        var id = await _courseService.AddCourseAsync(request, ct);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] CourseDto courseDto)
    {
        if (id != courseDto.Id)
            return BadRequest();

        await _courseService.UpdateCourseAsync(courseDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _courseService.DeleteCourseAsync(id);
        return NoContent();
    }
}