using FluentValidation;
using WebApi.Entities;
using WebApi.Application.OrderOperation.Commands.DeleteOrder;

namespace WebApi.Application.OrderOperation.Commands.DeleteOrderValidator
{
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(a=>a.Model.OrderId).NotEmpty();
        }  
    }
}        