using BaseRepositoryWithUnitOfWork;

namespace ToDoListWebAPI.Application;

public class ToDoListItem : IEntity
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsComplete { get; set; }
}
