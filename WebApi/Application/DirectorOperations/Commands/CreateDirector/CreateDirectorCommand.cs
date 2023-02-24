using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.DirectorOperation.Commands.CreateDirector
{
    public class CreateDirectorCommand
    {
        public CreateDirectorModel Model { get; set; }

        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateDirectorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var director = _context.Directors.SingleOrDefault(x => x.Name == Model.Name && x.Surname == Model.Surname);
            if (director is not null)
                 throw new InvalidOperationException("Bu Direktör Zaten Mevcut");

            director= _mapper.Map<Director>(Model);
            _context.Directors.Add(director);
            _context.SaveChanges();     
        }
    }

    public class CreateDirectorModel
    {
       public string Name { get; set; }
       public string Surname { get; set; }
       public string FilmsDirected { get; set; }
    }
}