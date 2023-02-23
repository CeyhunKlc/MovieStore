using FluentValidation;
using WebApi.Entities;
using WebApi.Application.GenreOperation.Commands.UpdateGenre;

namespace WebApi.Application.GenreOperation.Commands.UpdateGenreValidator
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