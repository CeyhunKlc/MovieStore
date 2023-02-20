using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Common;
using WebApi.dbOperations;
using AutoMapper;
using WebApi.Entities;

namespace WebApi.Application.DirectorOperation.Commands.UpdateDirector
{
    public class DeleteDirectorCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int DirectorId { get; set; }
        public UpdateDirectorModel Model { get; set; }

        public UpdateDirectorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var director = _context.Directors.SingleOrDefault(x => x.Id == DirectorId);

            if (director == null)
                throw InvalidOperationException("Direktör Bulunamadı");

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