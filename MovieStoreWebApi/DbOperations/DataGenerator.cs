using System;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;



namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceprovider)
        {
            using (var context = new MovieStoreDbContext(serviceprovider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;
                }

                context.Directors.AddRange(
                   new Director { Name = "Justin", Surname = "Lin", FilmsDirected = "Hızlı Ve Öfkeli", IsActive = true },
                   new Director { Name = "Louis ", Surname = "Leterrier", FilmsDirected = "Taşıyıcı", IsActive = true },
                   new Director { Name = "Corey ", Surname = "Yuen", FilmsDirected = "Taşıyıcı", IsActive = true }
                );
                context.SaveChanges();

                context.Actors.AddRange(
                    new Actor { Id=1,Name = "Vin", Surname = "Diesel",PlayedMovies="Hızlı Ve Öfkeli" },
                    new Actor { Id = 2,Name = "Paul", Surname ="Walker", PlayedMovies="Hızlı Ve Öfkeli" },
                    new Actor { Id = 3,Name = "Dwayne", Surname = "Johnson",PlayedMovies="Hızlı Ve Öfkeli" },
                    new Actor { Id = 4,Name = "Jason", Surname = "Statham",PlayedMovies="Taşıyıcı" },
                    new Actor { Id = 5,Name = "Rich", Surname = "Young",PlayedMovies="Taşıyıcı" }
                );
                context.SaveChanges();

                context.Movies.AddRange(
                   new Movie
                   {
                       // ID = 1,
                       GenreId = 1,
                       Title = "Hızlı Ve Öfkeli",
                       Year = "2013",
                       Director = "Justin Lin",
                       Actors = "Vin Diesel, Paul Walker, Dwayne Johnson,",
                       Price = 50,
                       IsActive = true
                   },

                   new Movie
                   {
                       // ID = 2,
                       GenreId = 2,
                       Title = "Taşıyıcı",
                       Year = "2002",
                       Director = "Louis Leterrier , Corey Yuen",
                       Actors = " Jason Statham, Rich Young",
                       Price = 45,
                       IsActive = true
                   }
                   );

                   context.Genres.AddRange(
                    new Genre
                    {
                        Name ="Aksiyon"
                    },
                    new Genre
                    {
                        Name ="Bilim Kurgu"
                    },
                    new Genre
                    {
                        Name ="Gerilim"
                    }
                   );
                   context.SaveChanges();

                context.Orders.AddRange(
                    new Order {CustomerId=1,MovieId=1,purchasedTime = new DateTime(2023,02,20), IsActive= true},
                    new Order {CustomerId=2,MovieId=1,purchasedTime = new DateTime(2023,02,19), IsActive= true},
                    new Order {CustomerId=3,MovieId=2,purchasedTime = new DateTime(2023,02,10), IsActive= true}
                );

                context.Customers.AddRange(

                    new Customer
                {
                    Id = 1,
                    Name = "ceyhun",
                    Surname = "kilic",
                    Email = "ceyhun@mail.com",
                    Password = "123456",
                    IsActive = true        
                },

                new Customer
                {
                    Name = "mehmet",
                    Surname = "yılmaz",
                    Email = "mehmet@mail.com",
                    Password = "1234567",
                    IsActive = true        
                },

                new Customer
                {
                    Name = "ali",
                    Surname = "demir",
                    Email = "ali@mail.com",
                    Password = "12345",
                    IsActive = true
                }            
                );

                context.SaveChanges(); 
            }
        }
    }
}
