
using CommandProcessor;

namespace ApplicationControl.DbApplicationControl;

public class ApplicationControlService : IApplicationControlService
{
    private readonly IApplicationControlRepository _applicationControlRepository;
    private readonly ICommandProcessor _commandProcessor;

    public ApplicationControlService(IApplicationControlRepository applicationControlRepository, ICommandProcessor commandProcessor)
    {
        ArgumentNullException.ThrowIfNull(applicationControlRepository, nameof(applicationControlRepository));
        ArgumentNullException.ThrowIfNull(commandProcessor, nameof(commandProcessor));

        _applicationControlRepository = applicationControlRepository;
        _commandProcessor = commandProcessor;
    }
   
    public Task<ApplicationControl> AddCommandAsync(string Command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task ExcecuteNextCommandAsync(CancellationToken cancellationToken)
    {
        var command = await _applicationControlRepository.GetNextCommandAsync(cancellationToken);
        if(command is not null)
        {
            var setBy = "system"; 
            try
            {
                await _applicationControlRepository.SetCommandStatusAsync(command.Id, setBy, CommandStatus.InProcess, string.Empty, cancellationToken);
                _commandProcessor.PprocessAsync(command.Command).Wait(cancellationToken);
                await _applicationControlRepository.SetCommandStatusAsync(command.Id, setBy, CommandStatus.Completed, string.Empty, cancellationToken);
            }
            catch(Exception ex)
            {
                await _applicationControlRepository.SetCommandStatusAsync(command.Id, setBy, CommandStatus.Failed, ex.Message, cancellationToken);
            }
        }
    }

    public Task<ApplicationControl?> GetCommandAsync(Guid commandId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CommandStatus?> GetCommandStatusAsync(Guid commandId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
