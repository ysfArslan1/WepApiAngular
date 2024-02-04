using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WepApiAngular.DBOperations;

namespace WepApiAngular.Aplication.BooksOperations.Commands.DeleteBook
{
    // DeleteBookCommand sınıfın için oluşturulan validation sınıfı.
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }
    }
}

