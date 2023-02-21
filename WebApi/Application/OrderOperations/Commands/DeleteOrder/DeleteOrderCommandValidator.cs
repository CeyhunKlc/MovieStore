using FluentValidation;

namespace WebApi.Application.OrderOperation.Commands.DeleteOrder
{
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(a=>a.Model.OrderId).NotEmpty();
        }  
    }
}        