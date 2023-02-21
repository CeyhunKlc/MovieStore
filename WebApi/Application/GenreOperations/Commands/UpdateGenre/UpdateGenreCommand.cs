using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Common;
using WebApi.dbOperations;
using WebApi.Entities;
using AutoMapper;

namespace WebApi.Application.GenreOperation.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public UpdateGenreModel Model { get; set; }
        public int GenreId { get; set; }
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        
        public UpdateGenreCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);

            if (genre == null)
            {
                throw new InvalidOperationException("Film Türü Bulunamadı");
            }

            _mapper.Map<UpdateGenreModel, Genre>(Model, genre);

            _context.Genres.Update(genre);
            _context.SaveChanges();
        }
    }

    public class UpdateGenreModel
    {        
        public string Name { get; set; }
        public bool IsActive {get; set;} = true;   
    }
}