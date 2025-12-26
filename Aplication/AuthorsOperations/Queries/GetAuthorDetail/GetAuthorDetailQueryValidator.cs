using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WepApi.Common;
using WepApi.DBOperations;
using WepApi.Aplication.AuthorsOperations.Queries.GetAuthorDetail;

namespace WepApi.Aplication.AuthorsOperations.Queries.GetAuthorDetail
{
    // GetAuthorDetailQuery sınıfın için oluşturulan validation sınıfı.
    public class GetAuthorDetailQueryValidator : AbstractValidator<GetAuthorDetailQuery>
    {

        public GetAuthorDetailQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }

    }

}
