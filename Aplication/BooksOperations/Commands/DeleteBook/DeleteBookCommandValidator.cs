using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WepApi.DBOperations;

namespace WepApi.Aplication.BooksOperations.Commands.DeleteBook
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

