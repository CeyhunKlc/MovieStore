using WebApi.Application.ActorOperation.Commands.CreateActor;
using WebApi.Application.ActorOperation.Commands.DeleteActor;
using WebApi.Application.ActorOperation.Commands.UpdateActor;
using WebApi.Application.ActorOperation.Queries.GetActorDetail;
using WebApi.Application.CustomerOperation.Commands.CreateCustomer;
using WebApi.Application.CustomerOperation.Commands.DeleteCustomer;
using WebApi.Application.DirectorOperation.Commands.CreateDirector;
using WebApi.Application.DirectorOperation.Commands.DeleteDirector;
using WebApi.Application.DirectorOperation.Commands.UpdateDirector;
using WebApi.Application.DirectorOperation.Queries.GetDirectors;
using WebApi.Application.DirectorOperation.Queries.GetDirectorDetail;
using WebApi.Application.GenreOperation.Commands.CreateGenre;
using WebApi.Application.GenreOperation.Commands.DeleteGenre;
using WebApi.Application.GenreOperation.Commands.UpdateGenre;
using WebApi.Application.GenreOperation.Queries.GetGenreDetail;
using WebApi.Application.GenreOperation.Queries.GetGenre;
using WebApi.Application.MovieOperation.Commands.CreateMovie;
using WebApi.Application.MovieOperation.Commands.DeleteMovie;
using WebApi.Application.MovieOperation.Commands.UpdateMovie;
using WebApi.Application.MovieOperation.Queries.GetMovieDetail;
using WebApi.Application.MovieOperation.Queries.GetMovie;
using WebApi.Application.OrderOperation.Commands.CreateOrder;
using WebApi.Application.OrderOperation.Commands.DeleteOrder;
using WebApi.Application.OrderOperation.Commands.UpdateOrder;
using WebApi.Application.OrderOperations.Model;
using WebApi.Application.OrderOperation.Queries.GetOrderDetailQuery;
using WebApi.Application.OrderOperation.Queries.GetOrders;
using WebApi.Application.OrderOperations.Model;
using WebApi.Application.TokenOperations;
using WebApi.Entities;
using AutoMapper;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Movei
            CreateMap<Movie, MoviesViewModel>()
            .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.Genre.Name));

            CreateMap<Movie, MovieDetailViewModel>()
            .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.Genre.Name));

            CreateMap<Movie, CreateMovieModel>().ReverseMap();

           
            CreateMap<UpdateMovieModel, Movie>().ReverseMap();

            //Genre

            CreateMap<Genre , CreateGenreModel>().ReverseMap();
            
            CreateMap<Genre, GenreDetailViewModel>().ReverseMap();
           

            CreateMap<CreateGenreCommand, Genre >().ReverseMap();

            CreateMap<UpdateGenreModel, Genre >().ReverseMap();

            //Customer 
            CreateMap<Customer, CreateCustomerModel>().ReverseMap();

            //Actor
            CreateMap<Actor, CreateActorModel>().ReverseMap();

            CreateMap<Actor, UpdateActorModel>().ReverseMap();


            //Director
            CreateMap<Director, CreateDirectorModel>().ReverseMap();

            CreateMap<Director, UpdateDirectorModel>().ReverseMap();

            CreateMap<Director, GetListDirectorModel>().ReverseMap();

            CreateMap<Director, GetByIdDirectorModel>().ReverseMap();


            //Order
            CreateMap<CreateOrderModel, Order>().ReverseMap();
            CreateMap<UpdateOrderModel, Order>().ReverseMap();

            CreateMap<Customer, OrderViewModel>()
                .ForMember(dest => dest.NameSurname, opt => opt.MapFrom(m => m.Name + " " + m.Surname))
                .ForMember(dest => dest.Movies, opt => opt.MapFrom(m => m.Orders.Select(s => s.Movie.Title)))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(m => m.Orders.Select(s => s.Movie.Price)))
                .ForMember(dest => dest.PurchasedDate, opt => opt.MapFrom(m => m.Orders.Select(s => s.purchasedTime)));



        }
    }
}