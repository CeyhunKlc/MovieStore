 using FluentValidation;
 using WebApi.Entities;


 namespace WebApi.Application.GenreOperation.Commands.UpdateGenre
 {
     public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
     {
         public UpdateGenreCommandValidator()
         {
             RuleFor(g => g.Model.Name).NotEmpty().MinimumLength(2);
         }
     }
 }