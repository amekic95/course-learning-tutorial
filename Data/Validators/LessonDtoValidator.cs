using FluentValidation;
using course_learning_tutorial.Data.DTOs;

namespace course_learning_tutorial.Data.Validators;

public sealed class LessonDtoValidator : AbstractValidator<LessonDto>
{
    public LessonDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.CourseId)
            .GreaterThan(0);
    }
}


