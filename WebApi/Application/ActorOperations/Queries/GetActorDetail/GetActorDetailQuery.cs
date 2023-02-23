using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.dbOperations;
using WebApi.Entities;

namespace WebApi.Application.ActorOperation.Queries.GetActorDetail
{
    public class GetActorDetailQuery
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public int ActorId { get; set; }

        public GetActorDetailQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ActorDetailViewModel Handle()
        {
            var actor = _context.Actors.SingleOrDefault(x => x.Id == ActorId);
            if (actor is null)
                throw new InvalidOperationException("Aktör Bulunamadı");
            return _mapper.Map<ActorDetailViewModel>(actor);
        }
    }

    public class ActorDetailViewModel
    {
        public String Name { get; set; }
        public string Surname { get; set; }
        public string PlayedMovies { get; set; }
    }
}