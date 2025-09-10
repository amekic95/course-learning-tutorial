using FluentValidation;
using course_learning_tutorial.Data.DTOs;

namespace course_learning_tutorial.Data.Validators;

public sealed class AuthorDtoValidator : AbstractValidator<AuthorDto>
{
    public AuthorDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);
    }
}


