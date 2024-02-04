using Microsoft.EntityFrameworkCore;
using WepApiAngular.DBOperations;

namespace WepApiAngular.Aplication.GenresOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int Id { get; set; }
        private readonly IAngularDbContext _dbContext;
        public DeleteGenreCommand(IAngularDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            // id üzerinden database sorgusu yapılır
            var item = _dbContext.Genres.Where(x => x.Id == Id).FirstOrDefault();
            if (item is null)
                throw new InvalidOperationException("Genre Bulunamadı");
            // database işlemleri yapılır.
            _dbContext.Genres.Remove(item);
            _dbContext.SaveChanges();

        }
    }
}

