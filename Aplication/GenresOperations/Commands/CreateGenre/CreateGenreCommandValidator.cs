
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WepApi.Common;
using WepApi.DBOperations;
using WepApi.Entities;

namespace WepApi.Aplication.GenresOperations.Commands.CreateGenre
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
