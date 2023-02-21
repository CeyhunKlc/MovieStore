using FluentValidation;

namespace WebApi.Application.GenreOperation.Queries.GetGenreDetail
{
    public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
    {
        GetGenreDetailQueryValidator()
        {
            Rulefor(query => query.GenreId).GreaterThan(0);
        }
    }
}