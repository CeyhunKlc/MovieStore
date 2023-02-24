using FluentValidation;
using WebApi.Entities;
using WebApi.DbOperations;
namespace WebApi.Application.ActorOperation.Commands.UpdateActor
{
    public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorCommandValidator()
        {
         //RuleFor(command => command.Model.ActorId).GreaterThan(0);
         //RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(2);
        }
    }
}