using FluentValidation;
using WebApi.Entities;
using WebApi.Application.MovieOperation.Commands.DeleteMovie;

namespace WebApi.Application.MovieOperation.Commands.DeleteMovieValidator
{
    public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
    {
        public DeleteMovieCommandValidator()
        {
            RuleFor(Command =>Command.MovieId).GreaterThan(0).NotEmpty();
        }
    } 
}           