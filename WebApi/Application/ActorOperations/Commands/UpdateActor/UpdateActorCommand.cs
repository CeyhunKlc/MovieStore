using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Common;
using WebApi.dbOperations;
using WebApi.Entities;

namespace WebApi.Application.ActorOperation.Commands.UpdateActor
{
    public class UpdateActorCommand
    {
        private readonly MovieStoreDbContext _context;
        public int ActorId { get; set; }
        public UpdateActorModel Model { get; set; }

        public UpdateActorCommand(MovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(x => x.Id == ActorId);

            if (actor is null)
                throw InvalidOperationException("Aktör Bulunamadı");

            actor.Name = Model.Name == default ? actor.Name : Model.Name;
            actor.Surname = Model.Surname == default ? actor.Surname : Model.Surname;
            
            _context.Actors.Update(actor);
            _context.SaveChanges();


        }
    }

    public class UpdateActorModel
    {
        public string Name {get; set;}
        public string Surname {get; set;}
        public string PlayedMovies { get; set; }
    }
}