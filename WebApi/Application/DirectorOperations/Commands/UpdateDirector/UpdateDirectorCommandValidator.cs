using FluentValidation;
using WebApi.Entities;
using WebApi.Application.DirectorOperation.Commands.UpdateDirector;

namespace WebApi.Application.DirectorOperation.Commands.UpdateDirectorValidator
{
    public class UpdateDirectorCommandValidator : AbstractValidator<UpdateDirectorCommand>
    {
        public UpdateDirectorCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty(0);
            RuleFor(command => command.Model.Surname).NotEmpty(0);
            RuleFor(command => command.Model.FilmsDirected).NotEmpty(0);
        }
    }
}