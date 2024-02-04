using Microsoft.EntityFrameworkCore;
using WepApiAngular.Entities;
using Ab_pk_task_AuthorController.Entities;

namespace WepApiAngular.DBOperations;

public interface IAngularDbContext 
{ 
    DbSet<Genre> Genres { get; set; }
    DbSet<Book> Books { get; set; }
    DbSet<Author> Authors { get; set; }
    int SaveChanges();

}

