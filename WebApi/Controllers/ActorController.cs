using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ActorOperation.Commands.CreateActor;
using WebApi.Application.ActorOperation.Commands.DeleteActor;
using WebApi.Application.ActorOperation.Commands.UpdateActor;
using WebApi.Application.ActorOperation.Queries.GetActorDetail;
using WebApi.Application.ActorOperation.Queries.GetActors;
using WebApi.dbOperations;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route ("api/[controller]/[action]")]
    [apiController]
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
        public IActionResult Create([FromBody] CreateActorCommand createActor)
        {
            CreateActorCommand  command = new CreateActorCommand(_context,_mapper);
            command.Model = createActor;
            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            DeleteActorCommand  command = new DeleteActorCommand(_context);
            command.ActorId = id;
            command.Handle();

            return Ok();
        }

        [HttpGet]
        public IActionResult GetList()
        {
            GetActorQuery query = new GetActorQuery(_context,_mapper);
            var result = query.Handle();
            return Ok (result);
        }
        
    }    
}