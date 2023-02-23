using FluentValidation;
using WebApi.Entities;
using WebApi.Application.OrderOperation.Commands.UpdateOrder;

namespace WebApi.Application.OrderOperation.Commands.UpdateOrderValidator
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(a=>a.Model.OrderId).NotEmpty();
            RuleFor(a=>a.Model.CustomerId).NotEmpty();
            RuleFor(a=>a.Model.MovieId).NotEmpty();
        }  
    }
}        