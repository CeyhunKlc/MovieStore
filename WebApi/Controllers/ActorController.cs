// using System;
// using System.Collections.Generic;
// using System.Linq;
// using FluentValidation.Results;
// using Microsoft.AspNetCore.Authorization;
// using AutoMapper;
// using FluentValidation;
// using Microsoft.AspNetCore.Mvc;
// using WebApi.Application.ActorOperation.Commands.CreateActor;
// using WebApi.Application.ActorOperation.Commands.DeleteActor;
// using WebApi.Application.ActorOperation.Commands.UpdateActor;
// using WebApi.Application.ActorOperation.Queries.GetActorDetail;
// using WebApi.DbOperations;
// using WebApi.Entities;

// namespace WebApi.Controllers
// {
//     [Route ("api/[controller]/[action]")]
//     [ApiController]
//     public class ActorController : ControllerBase
//     {
//         private readonly IMovieStoreDbContext _Dbcontext;
//         private readonly IMapper _mapper;

//         public ActorController(IMovieStoreDbContext Dbcontext, IMapper mapper)
//         {
//             _Dbcontext = Dbcontext;
//             _mapper = mapper;
//         }

//         [HttpPost]
//         public IActionResult Create([FromBody] CreateActorCommand createActor)
//         {
//             CreateActorCommand  command = new CreateActorCommand(_Dbcontext,_mapper);
//             command.Model = CreateActorCommand;
//             command.Handle();

//             return Ok();
//         }

//         [HttpDelete("{id}")]
//         public IActionResult Delete([FromRoute] int id)
//         {
//             DeleteActorCommand  command = new DeleteActorCommand(_Dbcontext);
//             command.ActorId = id;
//             command.Handle();

//             return Ok();
//         }

//         [HttpGet]
//         public IActionResult GetList()
//         {
//             GetActorQuery query = new GetActorQuery(_context,_mapper);
//             var result = query.Handle();
//             return Ok (result);
//         }
        
//     }    
// }