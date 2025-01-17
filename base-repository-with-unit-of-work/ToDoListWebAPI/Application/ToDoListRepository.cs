using BaseRepositoryWithUnitOfWork;

namespace ToDoListWebAPI.Application;

public class ToDoListRepository : BaseRepository<ToDoListItem>, IToDoListRepository
{
    public ToDoListRepository(IContext context) : base(context)
    {
    }
}
