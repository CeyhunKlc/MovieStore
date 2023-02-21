using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.dbOperations;

namespace WebApi.Application.GenreOperation.Queries.GetGenre
{
    public class GetGenreQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetGenreQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GenresViewModel> Handle()
        {
            var genres = _context.Genres.OrderBy(x => x.Id);
            List<GenresViewModel> returnObj = _mapper.Map<List<GenresViewModel>>(genres);
            return returnObj;
        }
    }

    public class GenresViewModel
    {
        public string Name {get; set;}   
    }

}