using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.CustomerOperation.Commands.CreateCustomer
{
    public class CreateCustomerCommand
    {
        public CreateCustomerModel Model { get; set; }

        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateCustomerCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Name == Model.Name && x.Surname == Model.Surname);
            if (customer is not null)
                 throw new InvalidOperationException("Zaten Mevcut");

            customer= _mapper.Map<Customer>(Model);
            _context.Customers.Add(customer);
            _context.SaveChanges();     
        }
    }

    public class CreateCustomerModel
    {
       public string Name { get; set; }
       public string Surname { get; set; }
       public string Email { get; set; }
       public string Password { get; set; }
    }
}