using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WepApiAngular.DBOperations;

namespace WepApiAngular.Aplication.GenresOperations.Commands.DeleteGenre
{
    // DeleteStudentCommand sınıfın için oluşturulan validation sınıfı.
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }
    }
}

