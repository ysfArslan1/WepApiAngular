
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WepApiAngular.Common;
using WepApiAngular.DBOperations;
using WepApiAngular.Entities;

namespace WepApiAngular.Aplication.BooksOperations.Commands.CreateBook
{
    // CreateBookCommant sınıfın için oluşturulan validation sınıfı.
    public class CreateBookCommandValidator : AbstractValidator<CreateBookModel>
    {
        public CreateBookCommandValidator()
        {

            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
            RuleFor(x => x.GenreId).NotEmpty();
            RuleFor(x => x.AuthorId).NotEmpty();
            RuleFor(x => x.PageCount).NotEmpty();
            RuleFor(x => x.PublishDate).NotEmpty().LessThan(DateTime.Now);
        }

    }
}
