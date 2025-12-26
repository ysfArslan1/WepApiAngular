
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WepApi.Common;
using WepApi.DBOperations;
using WepApi.Entities;

namespace WepApi.Aplication.GenresOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Model { get; set; }
        private readonly IAngularDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateGenreCommand(IAngularDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var item = _dbContext.Genres.Where(x => x.Name == Model.Name ).FirstOrDefault();
            if (item is not null)
                throw new InvalidOperationException("Zaten Mevcut");

            item = _mapper.Map<Genre>(Model);
            // database işlemleri yapılır.
            _dbContext.Genres.Add(item);
            _dbContext.SaveChanges();

        }
    }
    // genre sınıfı üretmek için gerekli verilerin alındıgı sınıf.
    public class CreateGenreModel
    {
        public string Name { get; set; }
    }
}
