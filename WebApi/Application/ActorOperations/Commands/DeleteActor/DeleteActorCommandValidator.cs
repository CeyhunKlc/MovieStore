using FluentValidation;

namespace WebApi.Application.ActorOperation.Commands.DeleteActor
{
    public class DeleteActorCommandValidator : AbstractValidator<DeleteActorCommand>
    {
        public DeleteActorCommandValidator()
        {
            RuleFor(Command =>Command.ActorId).GreaterThan(0).NotEmpty();
        }
    } 
}           