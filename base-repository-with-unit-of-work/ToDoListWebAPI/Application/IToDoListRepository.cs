using BaseRepositoryWithUnitOfWork;

namespace ToDoListWebAPI.Application;

public interface IToDoListRepository : IBaseRepository<ToDoListItem>
{
}
