using BaseRepositoryWithUnitOfWork;

namespace ToDoListWebAPI.Application;

public class ToDoListRepository : BaseRepository<ToDoListItem, int>, IToDoListRepository
{
    public ToDoListRepository(IToDoListDbContext context) : base(context)
    {
    }
}
