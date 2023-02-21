using AutoMapper;
using WebApi.Application.OrderOperations.Model;
using WebApi.dbOperations;
using WebApi.Entities;

namespace WebApi.Application.OrderOperation.Commands.UpdateOrder
{
    public class  UpdateOrderCommand
    {
        public UpdateOrderModel Model {get; set;}
        public int OrderId;
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateOrderCommand(IMovieStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            Customer customer = _context.Customers.SingleOrDefault(x => x.Id == CustomerId);
            Movie movies = _context.Movies.SingleOrDefault(x => x.Id == MovieId);

            Order order = _context.Orders.SingleOrDefault(x => x.Id == OrderId);

            if (customer is null)
                  throw new InvalidOperationException("Müşteri Bulunamadı");
            if (movies is null)
                  throw new InvalidOperationException("Film Bulunamadı");
            if (order is null)
                  throw new InvalidOperationException("Kayıt Bulunamadı");

            order.IsActive= false;

            _context.Orders.Update(order);
            _context.SaveChanges();     
        }
    }
}