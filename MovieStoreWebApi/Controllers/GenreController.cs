
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.GenreOperation.Commands.CreateGenre;
using WebApi.Application.GenreOperation.Commands.DeleteGenre;
using WebApi.Application.GenreOperation.Commands.UpdateGenre;
using WebApi.Application.GenreOperation.Queries.GetGenreDetail;
using WebApi.Application.GenreOperation.Queries.GetGenre;
using WebApi.DbOperations;
using FluentValidation;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        public readonly IMovieStoreDbContext _context;
        public readonly IMapper _mapper;

        public GenreController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            GetGenreQuery query = new GetGenreQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);  
            var result = query.Handle();
            return Ok(result);


        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateGenreModel model)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
            command.Model = model;

            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = id;

            command.Handle();
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateGenreModel model)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context, _mapper);

            command.GenreId = id;

            command.Model = model;

            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);
               

            command.Handle();
            return Ok();

        }
    }
}