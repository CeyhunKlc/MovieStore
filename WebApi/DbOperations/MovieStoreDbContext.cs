using Microsoft.EntityFrameworkCore;
using WebApi.Entities;
namespace WebApi.dbOperations
{
    public class MovieStoreDbContext : DbContext, IMovieStoreDbContext
    {
        public MovieStoreDbContext(dbContextOptions<MovieStoreDbContext> options) : base(options)
        { }
        public Dbset<Movie> Movies { get; set; }
        public Dbset<Actor> Actors { get; set; }


        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}