using WebApi.dbOperations;
using WebApi.Entities;

namespace WebApi.Application.OrderOperation.Commands.DeleteOrder
{
    public class  DeleteOrderCommand
    {
        public int OrderId;

        private readonly IMovieStoreDbContext _context;

        public DeleteOrderCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var order = _context.Orders.SingleOrDefault(x => x.Id == OrderId);

            if (order is null)
                 throw new InvalidOperationException("Kayıt Bulunamadı");

            order.IsActive= false;

            _context.Orders.Update(order);
            _context.SaveChanges();     
        }
    }
}