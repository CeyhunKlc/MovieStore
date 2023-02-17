using FluentValidation;

namespace WebApi.Application.ActorOperations.CreateActor
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