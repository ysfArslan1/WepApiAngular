using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WepApi.DBOperations;
using WepApi.Entities;
using WepApi.Aplication.GenresOperations.Commands.UpdateGenre;

namespace WepApi.Aplication.GenresOperations.Commands.UpdateGenre
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
