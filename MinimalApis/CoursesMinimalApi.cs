using course_learning_tutorial.Data.DTOs;
using course_learning_tutorial.Services;
using Microsoft.AspNetCore.Mvc;

namespace course_learning_tutorial.MinimalApis;

public static class CoursesMinimalApi
{
    public static void MapCourseEndpoints(this WebApplication app)
    {
        app.MapGet("/courses", async (ICourseService courseService, [FromQuery] string authorName) =>
        {
            try
            {
                var courses = await courseService.GetCoursesAsync(authorName);
                return Results.Ok(ApiResponseDto<IEnumerable<CourseDto>>.SuccessResult(courses));
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ApiResponseDto.ErrorResult(ex.Message));
            }
        })
        .Produces<ApiResponseDto<IEnumerable<CourseDto>>>(StatusCodes.Status200OK)
        .Produces<ApiResponseDto>(StatusCodes.Status400BadRequest)
        .WithTags("Courses")
        .WithOpenApi();
    }
}
