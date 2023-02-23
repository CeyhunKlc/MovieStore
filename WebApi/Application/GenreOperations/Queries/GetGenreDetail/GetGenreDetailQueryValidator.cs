using FluentValidation;
using WebApi.Entities;
using WebApi.Application.GenreOperation.Queries.GetGenreDetail;

namespace WebApi.Application.GenreOperation.Queries.GetGenreDetailValidator
{
    public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
    {
        GetGenreDetailQueryValidator()
        {
            Rulefor(query => query.GenreId).GreaterThan(0);
        }
    }
}