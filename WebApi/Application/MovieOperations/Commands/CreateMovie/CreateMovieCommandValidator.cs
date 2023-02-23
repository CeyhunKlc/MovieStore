using FluentValidation;
using WebApi.Entities;
using WebApi.Application.MovieOperation.Commands.CreateMovie;

namespace WebApi.Application.MovieOperation.Commands.CreateMovieValidator
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(a=>a.Model.GenreId).NotEmpty().GreaterThan(0);
            RuleFor(a=>a.Model.Price).NotEmpty().GreaterThan(0);
            RuleFor(a=>a.Model.Year).NotEmpty().MinimumLength(4).MaximumLength(4);
            RuleFor(a=>a.Model.Title).NotEmpty().MinimumLength(1);
            RuleFor(a=>a.Model.Actors).NotEmpty().MinimumLength(2);
            RuleFor(a=>a.Model.Director).NotEmpty().MinimumLength(2);
        }  
    }
}        