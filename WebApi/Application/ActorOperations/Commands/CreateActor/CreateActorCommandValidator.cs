using FluentValidation;
using WebApi.Entities;
using WebApi.Application.ActorOperation.Commands.CreateActor;

namespace WebApi.Application.ActorOperation.Commands.CreateActorValidator
{
    public class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>
    {
        public CreateActorCommandValidator()
        {
            RuleFor(a=>a.Model.Name).NotEmpty();
            RuleFor(a=>a.Model.Surname).NotEmpty();
            RuleFor(a=>a.Model.PlayedMovies).NotEmpty();
        }  
    }
}        