using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WepApi.Common;
using WepApi.DBOperations;
using WepApi.Aplication.BooksOperations.Queries.GetBookDetail;

namespace WepApi.Aplication.BooksOperations.Queries.GetBookDetail
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
