using System;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;
namespace WebApi.dbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceprovider)
        {
            using (var context= new MovieStoreDbContext(serviceprovider.GetRequiredService<DbContextOptions<BookStoreDBContext>>()))
            {
                if(context.Movies.Any())
                {
                    return;
                }

                context.Actors.AddRange(
                    new Actor
                    {
                        Name = "Leonardo DiCaprio"
                    },
                    new Actor
                    {
                        Name = "Brad Pitt"
                    },
                    new Actor
                    {
                        Name = "kate Winslet"
                    }
                );
            }
        }
    }
}
