using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Application.OrderOperations.Model;
using WebApi.dbOperations;
using WebApi.Entities;


namespace WebApi.Application.OrderOperation.Queries.GetOrderDetailQuery
{
    public class GetOrderDetailQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public int OrderId;

        public GetOrderDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public OrderViewModel Handle()
        {
            Customer customer = _context.Customers.Include(i =>i.Orders).ThenInclude(t=>t.movie).SingleOrDefault(s=>s.Id==OrderId);
            OrderViewModel vm = _mapper.Map<OrderViewModel>(customer);

            return vm;
        }
    }
}