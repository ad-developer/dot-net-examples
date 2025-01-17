using BaseRepositoryWithUnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace ToDoListWebAPI.Application;

public class ToDoListDbContext : DbContext, IToDoListDbContext
{
    public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options)
    {
    }

    public DbSet<ToDoListItem> ToDoListItems { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDoListItem>().HasKey(x => x.Id);
    }
}
