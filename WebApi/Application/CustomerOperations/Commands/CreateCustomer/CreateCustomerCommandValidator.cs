using FluentValidation;

namespace WebApi.Application.CustomerOperation.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(a=>a.Model.Name).NotEmpty();
            RuleFor(a=>a.Model.Surname).NotEmpty();
            RuleFor(a=>a.Model.Email).NotEmpty();
            RuleFor(a=>a.Model.Password).NotEmpty();
        }  
    }
}        