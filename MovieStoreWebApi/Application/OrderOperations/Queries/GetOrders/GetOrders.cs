using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Application.OrderOperations.Model;
using WebApi.DbOperations;
using WebApi.Entities;


namespace WebApi.Application.OrderOperation.Queries.GetOrders
{
    public class GetOrders
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetOrders(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<OrderViewModel> Handle()
        {
            List<Customer>list = _context.Customers.Include(i => i.Orders).ThenInclude(t => t.Movie).Where(w => w.Orders.Any(a => a.IsActive)).OrderBy(x => x.Id).ToList();
            List<OrderViewModel> vm  = _mapper.Map<List<OrderViewModel>>(list);

            return vm;
        }
    }
}
