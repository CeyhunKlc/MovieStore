using AutoMapper;
using WebApi.Application.ActorOperation.Commands.CreateActor;
using WebApi.Application.ActorOperation.Commands.DeleteActor;
using WebApi.Application.ActorOperation.Commands.UpdateActor;
using WebApi.Application.CustomerOperation.Commands.CreateCustomer;
using WebApi.Application.DirectorOperation.Commands.CreateDirector;
using WebApi.Application.DirectorOperation.Commands.UpdateDirector;
using WebApi.Application.DirectorOperations.Queries.GetListDirector;
using WebApi.Application.DirectorOperation.Queries.GetDirectors;
using WebApi.Application.GenreOperation.Commands.CreateGenre;
using WebApi.Application.GenreOperation.Commands.UpdateGenre;
using WebApi.Application.GenreOperation.Queries.GetGenreDetail;
using WebApi.Application.MovieOperation.Commands.CreateMovie;
using WebApi.Application.MovieOperation.Commands.UpdateMovie;
using WebApi.Application.MovieOperation.Queries.GetMovie;
using WebApi.Application.MovieOperation.Queries.GetMovieDetail;
using WebApi.Application.OrderOperations.Model;
using WebApi.Application.ActorOperation.Queries.GetActorss;
using WebApi.Entities;
using WebApi.DbOperations;
namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Movei
            CreateMap<Movie, MoviesViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));

            CreateMap<Movie, MovieDetailViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));

            CreateMap<Movie, CreateMovieModel>().ReverseMap();


            CreateMap<UpdateMovieModel, Movie>().ReverseMap();

            //Genre

            CreateMap<Genre, CreateGenreModel>().ReverseMap();

            CreateMap<Genre, GenreDetailViewModel>().ReverseMap();


            CreateMap<CreateGenreCommand, Genre>().ReverseMap();

            CreateMap<UpdateGenreModel, Genre>().ReverseMap();

            //Customer 
            CreateMap<Customer, CreateCustomerModel>().ReverseMap();

            //Actor
            CreateMap<Actor, CreateActorModel>().ReverseMap();

            CreateMap<Actor, ActorsViewModel>().ReverseMap();


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