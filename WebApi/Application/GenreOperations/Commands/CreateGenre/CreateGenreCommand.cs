using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.Common;
using WebApi.dbOperations;
using WebApi.Entities;


namespace WebApi.Application.GenreOperation.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Model { get; set; }
        
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateGenreCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.Name == Model.Name);

            if(genre != null)
               throw new InvalidOperationException("film Türü Zaten Mevcut"); 
            
            genre = _mapper.Map<Genre>(Model);

            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();
        }

        public class CreateGenreModel
        {
           public string Name { get; set; }
           
        }

    }
}
