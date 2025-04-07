
using FinalProject.Application.Models;
using FluentValidation;

namespace FinalProject.Application.Validators;

public class MovieValidator : AbstractValidator<Movie>
{

    public MovieValidator()
    {
        RuleFor(movie => movie.Title)
        .NotNull()
        .NotEmpty()
        .Length(2, 100);

        RuleFor(movie => movie.YearOfRelease)
            .LessThanOrEqualTo(DateTime.UtcNow.Year)
            .WithMessage("Year of release can't be greater than the current year");

    }
    //[Errors]
    //PropertyName -> YearOFrelease
    //ErrorMessage -> You are not in a future
}
