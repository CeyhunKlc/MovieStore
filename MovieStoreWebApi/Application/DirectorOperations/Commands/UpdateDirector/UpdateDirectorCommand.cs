using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Common;
using WebApi.DbOperations;
using AutoMapper;
using WebApi.Entities;
using System.IO;

namespace WebApi.Application.DirectorOperation.Commands.UpdateDirector
{
    public class UpdateDirectorCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int GenreId { get; set; }
        public UpdateDirectorModel Model { get; set; }

        public UpdateDirectorCommand(IMovieStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var director = _context.Directors.SingleOrDefault(x => x.Id == GenreId);

            if (director == null)
                throw new InvalidOperationException("Yönetmen Bulunamadı !");

            _mapper.Map<UpdateDirectorModel,Director>(Model,director);
            
            _context.Directors.Update(director);
            _context.SaveChanges();


        }
    }

    public class UpdateDirectorModel
    {
        public string Name {get; set;}
        public string Surname {get; set;}
        public string FilmsDirected { get; set; }
        public bool IsActive {get; set;}
    }
}