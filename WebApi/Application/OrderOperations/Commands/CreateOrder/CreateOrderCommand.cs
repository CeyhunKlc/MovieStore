using System;
using System.Linq;
using AutoMapper;
using WebApi.dbOperations;
using WebApi.Entities;

namespace WebApi.Application.OrderOperation.Commands.CreateOrder
{
    public class CreateOrderCommand
    {
        public CreateOrderModel Model ;

        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateOrderCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id ==Model.CustomerId);
            var movies = _context.Movies.SingleOrDefault(x => x.Id ==Model.MovieId);
            if (customer is not null)
                 throw new InvalidOperationException(" Müşteri Bulunamadı");

            if (movies is not null)
                 throw new InvalidOperationException(" Film Bulunamadı");     
     
             var result = _mapper.Map<Order>(Model);
             result.purchasedTime = DateTime.Now;
             result.IsActive = true;

             _context.Orders.Add(result);
             _context.SaveChanges();     
        }
    }

 
}