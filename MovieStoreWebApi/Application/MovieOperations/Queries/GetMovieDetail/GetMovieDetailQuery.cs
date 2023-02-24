using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.MovieOperation.Queries.GetMovieDetail
{
    public class GetMovieDetailQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public int MovieId { get; set; }

        public GetMovieDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public MovieDetailViewModel Handle()
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == MovieId);
            if (movie is null)
                throw new InvalidOperationException("kitap Bulunamadı");
            return _mapper.Map<MovieDetailViewModel>(movie);
        }
    }

    public class MovieDetailViewModel
    {
        public int GenreId { get; set; }
        public string Title{get; set;}
        public string Year { get; set; }
        public string Director { get; set; }
        public string Actors {get; set;}
        public int  Price {get; set;}
        public bool IsActive {get; set;} 
    }
}