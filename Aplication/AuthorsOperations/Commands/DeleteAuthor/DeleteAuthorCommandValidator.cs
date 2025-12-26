using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WepApi.DBOperations;

namespace WepApi.Aplication.AuthorsOperations.Commands.DeleteAuthor
{
    // DeleteAuthorCommand sınıfın için oluşturulan validation sınıfı.
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }
    }
}

