using FluentValidation;
using course_learning_tutorial.Data.DTOs;

namespace course_learning_tutorial.Data.Validators;

public sealed class CreateCourseRequestValidator : AbstractValidator<CreateCourseRequest>
{
    public CreateCourseRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.AuthorId)
            .GreaterThan(0);

        RuleForEach(x => x.LessonTitles)
            .NotEmpty()
            .MaximumLength(200);

        RuleForEach(x => x.StudentIds)
            .GreaterThan(0);
    }
}


