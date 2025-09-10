using AutoMapper;
using course_learning_tutorial.Data.DTOs;
using course_learning_tutorial.Data.Models;

namespace course_learning_tutorial.Data;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Course, CourseDto>()
            .ForMember(d => d.AuthorName, o => o.MapFrom(s => s.Author.Name))
            .ForMember(d => d.Students, o => o.MapFrom(s => s.CourseStudents.Select(cs => cs.Student)));

        CreateMap<Lesson, LessonDto>();
        CreateMap<Author, AuthorDto>();
        CreateMap<Student, StudentDto>();

        CreateMap<CreateCourseRequest, Course>()
            .ForMember(d => d.Lessons, o => o.Ignore())
            .ForMember(d => d.CourseStudents, o => o.Ignore());
    }
}