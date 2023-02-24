using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.DirectorOperation.Queries.GetDirectorDetail
{
    public class GetListDirectorQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public int DirectorId { get; set; }

        public GetListDirectorQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetListDirectorModel> Handle()
        {
            var directors = _context.Directors.Where(x => x.IsActive == true).Tolist<Director>();
            var mapModel = _mapper.Map.List<GetListDirectorModel>(directors);
            return mapModel;
        }
    }

    public class GetListDirectorModel
    {
        public String Name { get; set; }
        public string Surname { get; set; }
        public string FilmsDirected { get; set; }                                                                                                                                                                                                                                                                                                                                                           
    }
}