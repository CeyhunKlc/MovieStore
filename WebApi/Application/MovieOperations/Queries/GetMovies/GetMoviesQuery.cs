using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.MovieOperation.Queries.GetMovie
{
    public class GetMovieQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetMovieQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<MoviesViewModel> Handle()
        {
            var movies = _context.Movies.OrderBy(x => x.Id);
            List<MoviesViewModel> returnObj = _mapper.Map<List<MoviesViewModel>>(movies);
            return returnObj;
        }
    }

    public class MoviesViewModel
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