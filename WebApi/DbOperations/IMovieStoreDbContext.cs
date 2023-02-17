using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.dbOperations
{
    public interface IMovieStoreDbContext
    {
        Dbset<Actor> Actors { get; set; }
        
        int SaveChanges();
    }
}