using FluentValidation;

namespace WebApi.Application.OrderOperation.Commands.CreateOrder
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