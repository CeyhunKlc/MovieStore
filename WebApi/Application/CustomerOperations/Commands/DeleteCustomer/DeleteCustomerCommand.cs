using System;
using System.Linq;
using WebApi.dbOperations;
using WebApi.Entities;

namespace WebApi.Application.CustomerOperation.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int CustomerId { get; set; }

        public DeleteCustomerCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == CustomerId);
            if (customer == null)
                throw new InvalidOperationException("Silinecek müşteri Bulunamadı");

            _context.Customers.Remove(customer);
            _context.SaveChanges();    
        }
    }
}