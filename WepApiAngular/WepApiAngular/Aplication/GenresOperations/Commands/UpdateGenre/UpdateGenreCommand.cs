using Microsoft.EntityFrameworkCore;
using WepApiAngular.DBOperations;
using WepApiAngular.Entities;

namespace WepApiAngular.Aplication.GenresOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public int Id { get; set; }
        public UpdateGenreModel Model { get; set; }
        private readonly IAngularDbContext _dbContext;
        public UpdateGenreCommand(IAngularDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            // Alınan bilgilerle aynı kayıtın database bulunma durumuna bakılır.
            var item = _dbContext.Genres.Where(x => x.Id == Id).FirstOrDefault();
            if (item is null)
                throw new InvalidOperationException("Genre Bulunamadı");

            if(_dbContext.Genres.Any(x=> x.Name.ToLower() == item.Name.ToLower() && x.Id != item.Id))
                throw new InvalidOperationException("Aynı isim bulunmakta");

            item.Name = Model.Name != default ? Model.Name : item.Name;
            item.isActive = Model.isActive != default ? Model.isActive : item.isActive;

            // database işlemleri yapılır.
            _dbContext.Genres.Update(item);
            _dbContext.SaveChanges();

        }
    }
    // class_ sınıfı düzenlemek için gerekli verilerin alındıgı sınıf.
    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool isActive { get; set; }
    }
}
