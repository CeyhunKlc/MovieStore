using FluentValidation;
using WebApi.Entities;
using WebApi.Application.GenreOperation.Commands.CreateGenre;

namespace WebApi.Application.GenreOperation.Commands.CreateGenreValidator
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
    
            RuleFor(a=>a.Model.Name).NotEmpty().MinimumLength(2);
        
        }  
    }
}        