﻿using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WepApiAngular.DBOperations;
using WepApiAngular.Entities;
using WepApiAngular.Aplication.BooksOperations.Commands.UpdateBook;

namespace WepApiAngular.Aplication.BookOperations.Commands.UpdateBook
{
    // UpdateBookCommand sınıfın için oluşturulan validation sınıfı.
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {

        public UpdateBookCommandValidator()
        {

            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Model.Title).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Model.GenreId).NotEmpty();
            RuleFor(x => x.Model.AuthorId).NotEmpty();
            RuleFor(x => x.Model.PageCount).NotEmpty();
            RuleFor(x => x.Model.PublishDate).NotEmpty().LessThan(DateTime.Now);

        }
    }

}
