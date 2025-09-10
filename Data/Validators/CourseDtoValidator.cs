using FluentValidation;
using course_learning_tutorial.Data.DTOs;

namespace course_learning_tutorial.Data.Validators;

public sealed class CourseDtoValidator : AbstractValidator<CourseDto>
{
    public CourseDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.AuthorId)
            .GreaterThan(0);

        // Collections can be null when omitted in responses; validate items when present
        RuleForEach(x => x.Lessons).SetValidator(new LessonDtoValidator());
        RuleForEach(x => x.Students).SetValidator(new StudentDtoValidator());
    }
}


