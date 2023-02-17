using System;
using System.Linq;
using AutoMapper;
using WebApi.dbOperations;
using WebApi.Entities;

namespace WebApi.Application.ActorOperations.CreateActor
{
    public class CreateActorCommand
    {
        public CreateActorModel Model { get; set; }

        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateActorCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(x => x.Name == Model.Name && x.Surname == Model.Surname);
            if (actor is not null)
                 throw new InvalidOperationException("Bu Aktör Zaten Mevcut");

            actor= _mapper.Map<Actor>(Model);
            _context.Actors.Add(actor);
            _context.SaveChanges();     
        }
    }

    public class CreateActorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PlayedMovies { get; set; }
    }
}