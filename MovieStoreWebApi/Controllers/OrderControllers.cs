using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebApi.DbOperations;
using WebApi.Application.OrderOperation.Commands.CreateOrder;
using WebApi.Application.OrderOperation.Commands.DeleteOrder;
using WebApi.Application.OrderOperation.Commands.UpdateOrder;
using WebApi.Application.OrderOperations.Model;
using WebApi.Application.OrderOperation.Queries.GetOrderDetailQuery;
using WebApi.Application.OrderOperation.Queries.GetOrders;
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public readonly IMovieStoreDbContext _context;
        public readonly IMapper _mapper;

        public OrderController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            GetOrders query = new GetOrders(_context, _mapper);
            var response = query.Handle();

            return Ok(response);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetOrderDetailQuery query = new GetOrderDetailQuery(_context, _mapper);
            query.OrderId = id;

            var response = query.Handle();

            return Ok(response);

        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateOrderModel model)
        {
            CreateOrderCommand command = new CreateOrderCommand(_context, _mapper);
            command.Model = model;

            CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            DeleteOrderCommand command = new DeleteOrderCommand(_context);
            command.OrderId = id;

            command.Handle();
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateOrderModel model)
        {
            UpdateOrderCommand command = new UpdateOrderCommand(_context, _mapper);

            command.OrderId = id;

            command.Model = model;

            UpdateOrderCommandValidator validator = new UpdateOrderCommandValidator();
            validator.ValidateAndThrow(command);


            command.Handle();
            return Ok();
        }

    }
}