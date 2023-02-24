using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ActorOperation.Commands.CreateActor;
using WebApi.Application.ActorOperation.Commands.DeleteActor;
using WebApi.Application.ActorOperation.Queries.GetActorss;
using WebApi.DbOperations;
using WebApi.Common;

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

        [HttpGet]
        public IActionResult GetList()
        {
            var actors =_context.Actors.Where(x => x.IsActive == true).ToList<Actor>();
            
            var mapModel = _mapper.Map<List<ActorsViewModel>>(actors);

            return mapModel;
            // GetActorQuery query = new GetActorQuery (_context,_mapper);
            // var result = query.Handle();
            return Ok(mapModel);
        }

        //[HttpPost]
        //public IActionResult Create([FromBody] CreateActorModel createActor)
        //{
        //    CreateActorCommand command = new CreateActorCommand(_dbContext, _mapper);
        //    command.Model = createActor;
        //    command.Handle();

        //    return Ok();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete([FromRoute] int id)
        //{
        //    DeleteActorCommand command = new DeleteActorCommand(_Dbcontext);
        //    command.ActorId = id;
        //    command.Handle();

        //    return Ok();
        //}

        //[HttpGet]
        //public IActionResult GetList()
        //{
        //    GetActorQuery query = new GetActorQuery(_Dbcontext, _mapper);
        //    var result = query.Handle();
        //    return Ok(result);
        //}

    }
}