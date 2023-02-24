using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.ActorOperation.Queries.GetActorss
{
    public class GetActorQuery
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetActorQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<ActorsViewModel> Handle()
        {
            var actors = _context.Actors.OrderBy(x => x.Id);
            List<ActorsViewModel> returnObj = _mapper.Map<List<ActorsViewModel>>(actors);
            return returnObj;
        }
    }

    public class ActorsViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PlayedMovies { get; set; }
    }

}