using Microsoft.EntityFrameworkCore;
using WepApi.DBOperations;

namespace WepApi.Aplication.BooksOperations.Commands.DeleteBook
{
    public class DeleteBookCommand
    {
        public int Id { get; set; }
        private readonly IAngularDbContext _dbContext;
        public DeleteBookCommand(IAngularDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            // id üzerinden database sorgusu yapılır
            var item = _dbContext.Books.Where(x => x.Id == Id).FirstOrDefault();
            if (item is null)
                throw new InvalidOperationException("Kitap Bulunamadı");
            // database işlemleri yapılır.
            _dbContext.Books.Remove(item);
            _dbContext.SaveChanges();

        }
    }
}

