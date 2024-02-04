
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WepApiAngular.Common;
using WepApiAngular.DBOperations;
using WepApiAngular.Entities;

namespace WepApiAngular.Aplication.AuthorsOperations.Commands.CreateAuthor
{
    // CreateAuthorCommant sınıfın için oluşturulan validation sınıfı.
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorModel>
    {
        public CreateAuthorCommandValidator()
        {

            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Surname).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Birthdate).NotEmpty().LessThan(DateTime.Now.AddYears(-10));
        }

    }
}
