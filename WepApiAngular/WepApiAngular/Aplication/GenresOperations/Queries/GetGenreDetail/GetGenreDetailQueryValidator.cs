using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WepApiAngular.Common;
using WepApiAngular.DBOperations;
using WepApiAngular.Aplication.GenresOperations.Queries.GetGenreDetail;

namespace WepApiAngular.Aplication.GenresOperations.Queries.GetGenreDetail
{
    // GetStudentDetailQuery sınıfın için oluşturulan validation sınıfı.
    public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
    {

        public GetGenreDetailQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }

    }

}
