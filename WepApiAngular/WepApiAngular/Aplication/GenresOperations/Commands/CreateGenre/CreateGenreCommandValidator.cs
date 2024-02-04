
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WepApiAngular.Common;
using WepApiAngular.DBOperations;
using WepApiAngular.Entities;

namespace WepApiAngular.Aplication.GenresOperations.Commands.CreateGenre
{
    // CreateStudentCommant sınıfın için oluşturulan validation sınıfı.
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreModel>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        }

    }
}
