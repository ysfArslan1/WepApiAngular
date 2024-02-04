using Microsoft.EntityFrameworkCore;
using WepApiAngular.Entities;
using Ab_pk_task_AuthorController.Entities;

namespace WepApiAngular.DBOperations;

public class AngularDbContext : DbContext, IAngularDbContext
{
    public AngularDbContext(DbContextOptions<AngularDbContext> options) : base(options)
    {
    }

    public DbSet<Genre> Genres { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
}

