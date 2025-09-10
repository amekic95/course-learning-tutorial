using FluentValidation;
using course_learning_tutorial.Data.DTOs;

namespace course_learning_tutorial.Data.Validators;

public sealed class StudentDtoValidator : AbstractValidator<StudentDto>
{
    public StudentDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);
    }
}


