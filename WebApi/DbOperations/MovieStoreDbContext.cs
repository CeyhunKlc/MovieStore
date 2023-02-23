using Microsoft.EntityFrameworkCore;
using WebApi.Entities;


namespace WebApi.dbOperations
{
    public class MovieStoreDbContext : context, IMovieStoreDbContext
    {
        public MovieStoreDbContext(dbContextOptions<MovieStoreDbContext> options) : base(options)
        { }
        
        public Dbset<Movie> Movies { get; set; }
        public Dbset<Actor> Actors { get; set; }
        public Dbset<Genre> Genres { get; set; }
        public Dbset<Customer> Customers { get; set; }
        public Dbset<Director> Directors { get; set; }
        public Dbset<Order> Orders { get; set; }


        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}