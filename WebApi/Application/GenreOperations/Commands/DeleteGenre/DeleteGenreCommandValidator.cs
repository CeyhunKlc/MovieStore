 using FluentValidation;
 using WebApi.Entities;


 namespace WebApi.Application.GenreOperation.Commands.DeleteGenre
 {
     public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
     {
         public DeleteGenreCommandValidator()
         {
             RuleFor(Command =>Command.GenreId).GreaterThan(0).NotEmpty();
         }
     } 
 }           