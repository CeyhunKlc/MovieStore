using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.ActorOperation.Commands.DeleteActor
{
    public class DeleteActorCommand
    {
        private readonly MovieStoreDbContext _DbContext;
        public int ActorId { get; set; }

        public DeleteActorCommand(MovieStoreDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public void Handle()
        {
            var actor = _DbContext.Actors.SingleOrDefault(x => x.Id == ActorId);
            if (actor == null)
                throw new InvalidOperationException("Silinecek Aktör Bulunamadı");

            _DbContext.Actors.Remove(actor);
            _DbContext.SaveChanges();    
        }
    }
}