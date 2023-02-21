using FluentValidation;
namespace WebApi.Entities;

namespace WebApi.Application.CustomerOperation.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(a=>a.Model.Name).NotEmpty();
            RuleFor(a=>a.Model.Surname).NotEmpty();
            RuleFor(a=>a.Model.Email).NotEmpty();
            RuleFor(a=>a.Model.Password).NotEmpty();
        }  
    }
}        