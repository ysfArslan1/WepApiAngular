using Microsoft.EntityFrameworkCore;
using WepApiAngular.DBOperations;

namespace WepApiAngular.Aplication.AuthorsOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int Id { get; set; }
        private readonly IAngularDbContext _dbContext;
        public DeleteAuthorCommand(IAngularDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            // id üzerinden database sorgusu yapılır
            var item = _dbContext.Authors.Where(x => x.Id == Id).FirstOrDefault();
            if (item is null)
                throw new InvalidOperationException("Bulunamadı");

            var book = _dbContext.Books.Where(x => x.AuthorId == Id).FirstOrDefault();
            if (book != null)
                throw new InvalidOperationException("Bu yazarın kitabı Databasede yer almakta, Lütfen önce kitabı silin");

            // database işlemleri yapılır.
            _dbContext.Authors.Remove(item);
            _dbContext.SaveChanges();

        }
    }
}

