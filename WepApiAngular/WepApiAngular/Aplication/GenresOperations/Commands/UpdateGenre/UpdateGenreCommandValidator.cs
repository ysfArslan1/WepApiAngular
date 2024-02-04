using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WepApiAngular.DBOperations;
using WepApiAngular.Entities;
using WepApiAngular.Aplication.GenresOperations.Commands.UpdateGenre;

namespace WepApiAngular.Aplication.GenresOperations.Commands.UpdateGenre
{
    // UpdateStudentCommand sınıfın için oluşturulan validation sınıfı.
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {

        public UpdateGenreCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Model.isActive).NotEmpty();
        }
    }

}
