using AutoMapper;
using WebApi.Application.TokenOperations;
using WebApi.Application.TokenOperations.Models;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.CustomerOperations.Commands.CreateToken
{
    public class CreateTokenCommand
    {
        public CreateTokenModel Model;

        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CreateTokenCommand(IMovieStoreDbContext movieStoreDbContext, IMapper mapper, IConfiguration configuration)
        {
            _context = movieStoreDbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
            if (customer != null)
            {

                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(customer);

                customer.RehreshToken = token.RefreshToken;
                customer.RehreshTokenExpireDate = token.Expiration.AddMinutes(5);

                _context.SaveChanges();
                return token;
            }
            else
            {
                throw new InvalidOperationException("Email veya Şifre Hatalı !");
            }
        }

    }

    public class CreateTokenModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

}