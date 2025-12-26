
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WepApi.Common;
using WepApi.DBOperations;
using WepApi.Entities;
using Ab_pk_task_AuthorController.Entities;

namespace WepApi.Aplication.AuthorsOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model { get; set; }
        private readonly IAngularDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateAuthorCommand(IAngularDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var item = _dbContext.Authors.Where(x => x.Name.ToLower() == Model.Name.ToLower() && x.Surname.ToLower() == Model.Surname.ToLower() )
                .FirstOrDefault();
            if (item is not null)
                throw new InvalidOperationException("Zaten Mevcut");

            item = _mapper.Map<Author>(Model);
            // database işlemleri yapılır.
            _dbContext.Authors.Add(item);
            _dbContext.SaveChanges();

        }
    }
    // Author sınıfı üretmek için gerekli verilerin alındıgı sınıf.
    public class CreateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
