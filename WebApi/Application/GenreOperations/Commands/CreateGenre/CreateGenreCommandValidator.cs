using FluentValidation;

namespace WebApi.Application.GenreOperation.Commands.CreateGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
    
            RuleFor(a=>a.Model.Name).NotEmpty().MinimumLength(2);
        
        }  
    }
}        