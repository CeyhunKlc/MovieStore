using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.CustomerOperation.Commands.CreateCustomer;
using WebApi.Application.CustomerOperation.Commands.DeleteCustomer;
using WebApi.Application.CustomerOperations.Commands.RefreshToken;
using WebApi.Application.CustomerOperations.Commands.CreateToken;
using WebApi.Application.TokenOperations.Models;
using WebApi.DbOperations;
using Microsoft.Extensions.Configuration;


namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class CustomerController  : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CustomerController(IMovieStoreDbContext context ,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public IActionResult CreateCustomer([FromBody] CreateCustomerModel newCustomer)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
            command.Model = newCustomer;
            command.Handle();

            return Ok();
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {

            CreateTokenCommand command = new CreateTokenCommand(_context, _mapper, _configuration);
            command.Model = login;
            var token = command.Handle();
            return token;
        }

        [HttpGet("refreshToken")]
        public ActionResult<Token> RefreshToken([FromQuery] string token)
        {

            RefreshTokenCommand command = new RefreshTokenCommand(_context, _configuration);
            command.RefrehToken = token;
            var result = command.Handle();
            return result;

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer([FromRoute] int id)
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(_context);
            command.CustomerId = id;

            command.Handle();

            return Ok();

        }
    }
}