using BaseRepositoryWithUnitOfWork;

namespace ApplicationControl.DbApplicationControl;

public interface IApplicationControlRepository : IBaseRepository<ApplicationControl, Guid>
{
    Task<ApplicationControl?> GetNextCommandAsync(CancellationToken cancellationToken);
    Task SetCommandStatusAsync(Guid commandId, string setBy,CommandStatus commandStatus, string message, CancellationToken cancellationToken);
}
