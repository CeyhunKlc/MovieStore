using FluentValidation;

namespace WebApi.Application.DirectorOperation.Commands.DeleteDirector
{
    public class DeleteDirectorCommandValidator : AbstractValidator<DeleteDirectorCommand>
    {
        public DeleteDirectorCommandValidator()
        {
            RuleFor(Command =>Command.DirectorId).GreaterThan(0).NotEmpty();
        }
    } 
}           