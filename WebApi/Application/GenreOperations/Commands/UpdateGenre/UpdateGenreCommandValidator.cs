using FluentValidation;

namespace WebApi.Application.GenreOperation.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(2);
        }
    }
}