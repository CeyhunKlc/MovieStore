using FluentValidation;

namespace WebApi.Application.MovieOperation.Commands.UpdateMovie
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