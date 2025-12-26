using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WepApi.DBOperations;
using WepApi.Entities;
using WepApi.Aplication.AuthorsOperations.Commands.UpdateAuthor;

namespace WepApi.Aplication.AuthorsOperations.Commands.UpdateAuthor
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
