using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Application.ActorOperation.Commands.CreateActor;
using WebApi.Application.ActorOperation.Commands.DeleteActor;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public ActorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        [HttpPost]
        public IActionResult CreateDefaultActors()
        {
            _context.Actors.AddRange(
                     new Actor { Id = 6, Name = "Vin", Surname = "Diesel", PlayedMovies = "Hızlı Ve Öfkeli" },
                    new Actor { Id = 7, Name = "Paul", Surname = "Walker", PlayedMovies = "Hızlı Ve Öfkeli" },
                    new Actor { Id = 8, Name = "Dwayne", Surname = "Johnson", PlayedMovies = "Hızlı Ve Öfkeli" },
                    new Actor { Id = 9, Name = "Jason", Surname = "Statham", PlayedMovies = "Taşıyıcı" },
                    new Actor { Id = 10, Name = "Rich", Surname = "Young", PlayedMovies = "Taşıyıcı" }
                );
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public  IActionResult GetList()
        {
             
            var actors = _context.Actors.ToList();

            //var mapModel = _mapper.Map<ActorsViewModel>(actors);
            // GetActorQuery query = new GetActorQuery (_context,_mapper);
            // var result = query.Handle();
            return Ok(actors);
        }

        [HttpPost]
        public IActionResult Create(CreateActorModel createActor)
        {
            Actor actor = _mapper.Map<Actor>(createActor);
            _context.Actors.Add(actor);
            _context.SaveChanges();

            var result = _mapper.Map<CreateActorModel>(actor);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var actor = _context.Actors.SingleOrDefault(x => x.Id == id );
            if (actor == null)
                throw new InvalidOperationException("Silinecek Aktör Bulunamadı");

            _context.Actors.Remove(actor);
            _context.SaveChanges();
           

            return Ok();
        }


    }
}