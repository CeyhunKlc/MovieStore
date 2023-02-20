using FluentValidation;

namespace WebApi.Application.MovieOperation.Commands.DeleteMovie
{
    public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
    {
        public DeleteMovieCommandValidator()
        {
            RuleFor(Command =>Command.MovieId).GreaterThan(0).NotEmpty();
        }
    } 
}           