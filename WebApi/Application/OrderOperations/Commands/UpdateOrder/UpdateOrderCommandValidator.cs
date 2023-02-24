using FluentValidation;
using WebApi.Entities;


namespace WebApi.Application.OrderOperation.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
          //  RuleFor(a=>a.Model.OrderId).NotEmpty();
          //  RuleFor(a=>a.Model.CustomerId).NotEmpty();
          //  RuleFor(a=>a.Model.MovieId).NotEmpty();
        }  
    }
}        