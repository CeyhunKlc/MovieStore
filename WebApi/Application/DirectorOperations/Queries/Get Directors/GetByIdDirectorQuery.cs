using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.dbOperations;

namespace WebApi.Application.DirectorOperation.Queries.GetDirectors
{
    public class GetDirectorQuery
    {
        public int DirectorId { get; set; }

        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetDirectorQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
         public GetByIdDirectorModel Handle()
        {
            var director = _movieStoreDbContext.Directors.SingleOrDefault(g => g.Id == DirectorId);

            if (director == null)
            {
                throw new InvalidOperationException("Yönetmen  bulunamadı ! ");
            }

            var model = _mapper.Map<GetByIdDirectorModel>(director);

            return model;


            
        }
    }
       public class GetByIdDirectorModel
       {
           public string Name { get; set; }
           public string Surname { get; set; }
           public string FilmsDirected { get; set; }
       }

}