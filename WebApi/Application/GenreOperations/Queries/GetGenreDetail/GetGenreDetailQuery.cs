using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.dbOperations;

namespace WebApi.Application.GenreOperation.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public int GenreId { get; set; }

        public GetGenreDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre == null)
                throw new InvalidOperationException("Film Türü Bulunamadı");
            return _mapper.Map<GenreDetailViewModel>(genre);
        }
    }

    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
         
    }
}