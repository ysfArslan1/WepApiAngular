using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WepApiAngular.Common;
using WepApiAngular.DBOperations;
using WepApiAngular.Aplication.AuthorsOperations.Queries.GetAuthorDetail;

namespace WepApiAngular.Aplication.AuthorsOperations.Queries.GetAuthorDetail
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
