using FluentValidation;
using WebApi.Entities;
using WebApi.Application.ActorOperation.Commands.DeleteActor;

namespace WebApi.Application.ActorOperation.Commands.DeleteActorValidator
{
    public class DeleteActorCommandValidator : AbstractValidator<DeleteActorCommand>
    {
        public DeleteActorCommandValidator()
        {
            RuleFor(Command =>Command.ActorId).GreaterThan(0).NotEmpty();
        }
    } 
}           