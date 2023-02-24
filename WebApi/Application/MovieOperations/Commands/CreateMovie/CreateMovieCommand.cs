using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.Common;
using WebApi.DbOperations;
using WebApi.Entities;


namespace WebApi.Application.MovieOperation.Commands.CreateMovie
{
    public class CreateMovieCommand
    {
        public CreateMovieModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private MovieStoreDbContext context;
        public CreateMovieCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Title == Model.Title);

            if(movie is not null)
               throw new InvalidOperationException("film zaten Mevcut"); 
            
            movie = _mapper.Map<Movie>(Model);

            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
        }

        
    }
    public class CreateMovieModel
        {
           public int GenreId { get; set; }
           public string Title{get; set;}
           public string Year { get; set; }
           public string Director { get; set; }
           public string Actors {get; set;}
           public int  Price {get; set;}
        }

}
