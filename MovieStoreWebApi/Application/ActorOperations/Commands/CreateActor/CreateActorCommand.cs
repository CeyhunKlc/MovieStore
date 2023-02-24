using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.ActorOperation.Commands.CreateActor
{
    public class CreateActorCommand
    {
        public CreateActorModel Model { get; set; }

        private readonly MovieStoreDbContext _Dbcontext;
        private readonly IMapper _mapper;

        public CreateActorCommand(MovieStoreDbContext Dbcontext, IMapper mapper)
        {
            _Dbcontext = Dbcontext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var actor = _Dbcontext.Actors.SingleOrDefault(x => x.Name == Model.Name && x.Surname == Model.Surname);
            if (actor is not null)
                 throw new InvalidOperationException("Bu Aktör Zaten Mevcut");

            actor= _mapper.Map<Actor>(Model);
            _Dbcontext.Actors.Add(actor);
            _Dbcontext.SaveChanges();     
        }
    }

    public class CreateActorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PlayedMovies { get; set; }
    }
}