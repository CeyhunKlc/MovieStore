using WebApi.Entities;
using WebApi.DbOperations;


namespace WebApi.Application.TokenOperations.Models

{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
    }
}