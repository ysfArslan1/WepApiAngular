using Microsoft.EntityFrameworkCore;
using WepApi.Entities;
using Ab_pk_task_AuthorController.Entities;

namespace WepApi.DBOperations;

public interface IAngularDbContext 
{ 
    DbSet<Genre> Genres { get; set; }
    DbSet<Book> Books { get; set; }
    DbSet<Author> Authors { get; set; }
    int SaveChanges();

}

