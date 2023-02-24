using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Common;
using WebApi.DbOperations;
using WebApi.Entities;
using AutoMapper;

namespace WebApi.Application.MovieOperation.Commands.UpdateMovie
{
    public class UpdateMovieCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int MovieId { get; set; }
        public UpdateMovieModel Model { get; set; }

        public UpdateMovieCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == MovieId);

            if (movie is null)
            {
                throw new InvalidOperationException("Film Bulunamadı");
            }


            _mapper.Map<UpdateMovieModel, Movie>(Model, movie);


            _context.Movies.Update(movie);
            _context.SaveChanges();


        }
    }

    public class UpdateMovieModel
    {
        public int GenreId { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public int Price { get; set; }
        public bool IsActive { get; set; }
    }
}