using WebApi.Application.TokenOperations;
using WebApi.Application.TokenOperations.Models;
using WebApi.DbOperations;


namespace WebApi.Application.CustomerOperations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
        public string RefrehToken;

        private readonly IMovieStoreDbContext _context;
        private readonly IConfiguration _configuration;

        public RefreshTokenCommand(IMovieStoreDbContext context, IConfiguration configuration)
        {
            _context = _context;
            _configuration = configuration;
        }

        public Token Handle()
        {

            var customer = _context.Customers.FirstOrDefault(x => x.RehreshToken == RefrehToken && x.RehreshTokenExpireDate > DateTime.Now);
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
                throw new InvalidOperationException("Valid bir refresh token bulunamadı !");
            }
        }

    }
}