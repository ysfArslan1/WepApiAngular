using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WepApiAngular.DBOperations;
using WepApiAngular.Entities;
using WepApiAngular.Aplication.AuthorsOperations.Commands.UpdateAuthor;

namespace WepApiAngular.Aplication.AuthorsOperations.Commands.UpdateAuthor
{
    // UpdateAuthorCommand sınıfın için oluşturulan validation sınıfı.
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {

        public UpdateAuthorCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Model.Surname).NotEmpty().MaximumLength(50); 
            RuleFor(x => x.Model.Birthdate).NotEmpty().LessThan(DateTime.Now.AddYears(-10)); 
        }
    }

}
