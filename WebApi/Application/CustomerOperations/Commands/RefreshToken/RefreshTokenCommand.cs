using WebApi.Application.TokenOperations;
using WebApi.Application.TokenOperations.Models;
using WebApi.DbOprations;

namespace WebApi.Application.CustomerOperation.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
        public string RefreshToken;

         private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IConfiguration _configuration;

        public RefreshTokenCommand(IMovieStoreDbContext movieStoreDbContext, IConfiguration configuration)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var customer = _movieStoreDbContext.Customers.FirstOrDefault(x=>x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate> DateTime.Now);
           if (customer != null)
            {

                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(customer);

                customer.RefreshToken = token.RefreshToken;
                customer.RefreshTokenExpireDate = token.Experation.AddMinutes(5);

                _movieStoreDbContext.SaveChanges();
                return token;

            }
            else
            {
                throw new InvalidOperationException(" token bulunamadı !");
            }
        }

    }
}