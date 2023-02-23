using FluentValidation;
using WebApi.Entities;
using WebApi.Application.OrderOperation.Commands.CreateOrder;

namespace WebApi.Application.OrderOperation.Commands.CreateOrderValidator
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(a=>a.Model.MovieId).NotEmpty();
            RuleFor(a=>a.Model.CustomerId).NotEmpty();
        }  
    }
}        