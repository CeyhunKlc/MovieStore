using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.MovieOperation.Commands.CreateMovie;
using WebApi.Application.MovieOperation.Commands.DeleteMovie;
using WebApi.Application.MovieOperation.Commands.UpdateMovie;
using WebApi.Application.MovieOperation.Queries.GetMovieDetail;
using WebApi.Application.MovieOperation.Queries.GetMovie;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public readonly IMovieStoreDbContext _context;
        public readonly IMapper _mapper;

        public MovieController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            GetMovieQuery query = new GetMovieQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            MovieDetailViewModel result;

            GetMovieDetailQuery query = new GetMovieDetailQuery(_context, _mapper);
            query.MovieId = id;

            result = query.Handle();

            return Ok(result);


        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateMovieModel model)
        {
            CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
            command.Model = model;

            CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            DeleteMovieCommand command = new DeleteMovieCommand(_context);
            command.MovieId = id;

            command.Handle();
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateMovieModel model)
        {
            UpdateMovieCommand command = new UpdateMovieCommand(_context, _mapper);

            command.MovieId = id;

            command.Model = model;

            UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
            validator.ValidateAndThrow(command);


            command.Handle();
            return Ok();
        }

    }
}
