using BaseRepositoryWithUnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace ToDoListWebAPI.Application;

public interface IToDoListDbContext : IContext
{
    DbSet<ToDoListItem> ToDoListItems { get; set; }
}
