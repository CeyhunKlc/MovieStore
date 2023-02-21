using System;
using System.Linq;
using WebApi.dbOperations;
using WebApi.Entities;

namespace WebApi.Application.ActorOperation.Commands.DeleteActor
{
    public class DeleteActorCommand
    {
        private readonly MovieStoreDbContext _context;
        public int ActorId { get; set; }

        public DeleteActorCommand(MovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(x => x.Id == ActorId);
            if (actor == null)
                throw new InvalidOperationException("Silinecek Aktör Bulunamadı");

            _context.Actors.Remove(actor);
            _context.SaveChanges();    
        }
    }
}