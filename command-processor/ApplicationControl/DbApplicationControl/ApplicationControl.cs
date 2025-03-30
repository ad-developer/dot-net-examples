using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaseRepositoryWithUnitOfWork;

namespace ApplicationControl.DbApplicationControl;

[Table("ApplicationControl", Schema = "AppControl")]
public class ApplicationControl : IEntity<Guid>
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public required string Command { get; set; }
    
    [Required]
    public required string AddedBy { get; set; }

    [Required]
    public required DateTime AddedDateTime { get; set; }
    
    public DateTime? UpdatedDateTime { get; set; }

    public string? UpdatedBy { get; set; }

    [Required]
    public CommandStatus Status { get; set; } 
    public string? Message { get; set; }
    
    public bool IsDeleted { get; set; } = false;
}
