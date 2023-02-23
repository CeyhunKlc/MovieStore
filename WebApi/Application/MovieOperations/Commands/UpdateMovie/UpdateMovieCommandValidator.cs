using FluentValidation;
using WebApi.Entities;
using WebApi.Application.MovieOperation.Commands.UpdateMovie;

namespace WebApi.Application.MovieOperation.Commands.UpdateMovieValidator
{
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {
            RuleFor(command => command.Model.MovieId).GreaterThan(0);
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(2);
        }
    }
}