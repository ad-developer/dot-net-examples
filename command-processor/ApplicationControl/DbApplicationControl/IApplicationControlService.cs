namespace ApplicationControl.DbApplicationControl;

public interface IApplicationControlService
{
    Task<ApplicationControl> AddCommandAsync(string Command, CancellationToken cancellationToken);
    Task ExcecuteNextCommandAsync(CancellationToken cancellationToken);
    Task<CommandStatus?> GetCommandStatusAsync(Guid commandId, CancellationToken cancellationToken);
    Task<ApplicationControl?> GetCommandAsync(Guid commandId, CancellationToken cancellationToken);
}