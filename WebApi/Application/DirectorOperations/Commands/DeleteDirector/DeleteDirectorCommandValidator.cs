using FluentValidation;
using WebApi.Entities;
using WebApi.Application.DirectorOperation.Commands.DeleteDirector;

namespace WebApi.Application.DirectorOperation.Commands.DeleteDirectorValidator
{
    public class DeleteDirectorCommandValidator : AbstractValidator<DeleteDirectorCommand>
    {
        public DeleteDirectorCommandValidator()
        {
            RuleFor(Command =>Command.DirectorId).GreaterThan(0).NotEmpty();
        }
    } 
}           