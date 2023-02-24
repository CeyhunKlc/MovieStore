using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ActorOperation.Commands.CreateActor;
using WebApi.Application.ActorOperation.Commands.DeleteActor;
using WebApi.Application.ActorOperation.Queries.GetActorss;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly MovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public ActorController(MovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Verileri Getir");
        }

        //[HttpPost]
        //public IActionResult Create([FromBody] CreateActorCommand createActor)
        //{
        //    CreateActorCommand command = new CreateActorCommand(_dbContext, _mapper);
        //    command.Model = CreateActorCommand;
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