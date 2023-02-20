using FluentValidation;

namespace WebApi.Application.DirectorOperation.Commands.CreateDirector
{
    public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
    {
        public CreateDirectorCommandValidator()
        {
            RuleFor(a=>a.Model.Name).NotEmpty();
            RuleFor(a=>a.Model.Surname).NotEmpty();
            RuleFor(a=>a.Model.FilmsDirected).NotEmpty();
        }  
    }
}        