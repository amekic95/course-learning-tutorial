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


    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponseDto<CourseDto>>> GetById(int id)
    {
        var course = await _courseService.GetCourseByIdAsync(id);
        if (course == null)
            return NotFound(ApiResponseDto<CourseDto>.ErrorResult($"Course with ID {id} not found"));
        return Ok(ApiResponseDto<CourseDto>.SuccessResult(course));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponseDto>> Create([FromBody] CreateCourseRequest request, CancellationToken ct)
    {
        try
        {
            await _courseService.AddCourseAsync(request, ct);
            return Ok(ApiResponseDto.SuccessResult("Course created successfully"));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponseDto.ErrorResult(ex.Message));
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponseDto>> Update(int id, [FromBody] CourseDto courseDto)
    {
        if (id != courseDto.Id)
            return BadRequest(ApiResponseDto.ErrorResult("Invalid ID"));

        try
        {
            await _courseService.UpdateCourseAsync(courseDto);
            return Ok(ApiResponseDto.SuccessResult("Course updated successfully"));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponseDto.ErrorResult(ex.Message));
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        if (id <= 0)
            return BadRequest(ApiResponseDto.ErrorResult("Invalid ID"));

        try
        {
            await _courseService.DeleteCourseAsync(id);
            return Ok(ApiResponseDto.SuccessResult("Course deleted successfully"));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponseDto.ErrorResult(ex.Message));
        }
    }
}
