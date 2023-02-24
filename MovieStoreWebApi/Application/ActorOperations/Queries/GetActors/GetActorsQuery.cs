using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.Common;

namespace WebApi.Application.ActorOperation.Queries.GetActorss
{
    public class GetActorQuery
    {
        public ActorsViewModel Model {get; set;}
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetActorQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<ActorsViewModel> Handle()
        {
            var actors =_context.Actors.Where(x => x.IsActive == true).ToList<Actor>();
            
            var mapModel = _mapper.Map<List<ActorsViewModel>>(actors);

            return mapModel;
        }
    }

    public class ActorsViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PlayedMovies { get; set; }
    }

}