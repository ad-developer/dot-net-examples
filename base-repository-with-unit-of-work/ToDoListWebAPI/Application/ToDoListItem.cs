using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaseRepositoryWithUnitOfWork;

namespace ToDoListWebAPI.Application;

[Table("ToDoListItem", Schema = "dbo")]
public class ToDoListItem : IEntity<int>
{
    [Key]
    public int Id { get; set; }
    public required string Description { get; set; }
    public bool IsComplete { get; set; }
    
    [NotMapped]
    public required string AddedBy { get; set; }
    [NotMapped]
    public DateTime AddedDateTime { get; set; }
    [NotMapped]
    public string? UpdatedBy { get; set; }
    [NotMapped]
    public DateTime? UpdatedDateTime { get; set; }
    [NotMapped]
    public bool IsDeleted { get; set; } = false;
}
