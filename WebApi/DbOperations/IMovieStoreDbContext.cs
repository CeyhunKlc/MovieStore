using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.dbOperations
{
    public interface IMovieStoreDbContext
    {
        Dbset<Genre> Genres { get; set; }
        Dbset<Movie> Movies { get; set; }
        public Dbset<Customer> Customers { get; set; }
        public Dbset<Actor> Actors { get; set; }
        public Dbset<Director> Directors { get; set; }
        public Dbset<Order> Orders { get; set; }
        
        
        
        
        int SaveChanges();
    }
}