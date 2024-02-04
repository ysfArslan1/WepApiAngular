using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WepApiAngular.Common;
using WepApiAngular.DBOperations;
using WepApiAngular.Aplication.BooksOperations.Queries.GetBookDetail;

namespace WepApiAngular.Aplication.BooksOperations.Queries.GetBookDetail
{
    // GetBookDetailQuery sınıfın için oluşturulan validation sınıfı.
    public class GetBookDetailQueryValidator : AbstractValidator<GetBookDetailQuery>
    {

        public GetBookDetailQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }

    }

}
