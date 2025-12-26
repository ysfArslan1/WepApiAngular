using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WepApi.Common;
using WepApi.DBOperations;
using WepApi.Aplication.GenresOperations.Queries.GetGenreDetail;

namespace WepApi.Aplication.GenresOperations.Queries.GetGenreDetail
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
