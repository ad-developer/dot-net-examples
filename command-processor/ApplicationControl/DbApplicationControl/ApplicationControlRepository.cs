using BaseRepositoryWithUnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace ApplicationControl.DbApplicationControl;

public class ApplicationControlRepository(IApplicationControlContext context) : BaseRepository<ApplicationControl, Guid>(context), IApplicationControlRepository
{
    public async Task<ApplicationControl?> GetNextCommandAsync(CancellationToken cancellationToken)
    {
          var nextCommand = 
              await  Entity
                        .Where(p => p.Status == CommandStatus.Queued)
                        .OrderBy(p => p.AddedDateTime)
                        .SingleOrDefaultAsync(cancellationToken);
        
        return  nextCommand;
    }

    public async Task SetCommandStatusAsync(Guid commandId, string setBy, CommandStatus commandStatus, string message, CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrEmpty(setBy, nameof(setBy));
        
        var cmd = await GetByIdAsync(commandId);
     
        if (cmd is null)
        {
            throw new InvalidOperationException($"Command with ID {commandId} not found.");
        }
        
        cmd.Status = commandStatus;
        if(!string.IsNullOrEmpty(message))
        {
            cmd.Message = message;
        }
        await UpdateAsync(cmd,setBy, cancellationToken);
    }
}
