using FluentValidation;
using WebApi.Entities;
using WebApi.Application.GenreOperation.Commands.DeleteGenre;

namespace WebApi.Application.GenreOperation.Commands.DeleteGenreValidator
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(Command =>Command.GenreId).GreaterThan(0).NotEmpty();
        }
    } 
}           