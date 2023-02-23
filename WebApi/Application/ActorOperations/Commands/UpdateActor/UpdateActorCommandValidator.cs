using FluentValidation;
using WebApi.Application.ActorOperation.Commands.UpdateActor;
using WebApi.Entities;

namespace WebApi.Application.ActorOperation.Commands.UpdateActorValidator
{
    public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorCommandValidator()
        {
            RuleFor(command => command.Model.ActorId).GreaterThan(0);
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(2);
        }
    }
}