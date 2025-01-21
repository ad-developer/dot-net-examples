using System.ComponentModel.DataAnnotations.Schema;
using BaseRepositoryWithUnitOfWork;

namespace ToDoListWebAPI.Application;

[Table("ToDoListItem", Schema = "dbo")]
public class ToDoListItem : IEntity
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsComplete { get; set; }
}
