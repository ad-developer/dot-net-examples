namespace CommanProcessor;

public class CommanProcessor : ICommandProcessor
{
    private readonly ICommandParser _commandParser;

    public CommanProcessor(ICommandParser commandParser)
    {
        _commandParser =commandParser;
    }
    
    public async Task PprocessAsync(string command)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(command);
        var cmd = await _commandParser.ParseAsync(command);
        var handler = InvokeCommandHandler(cmd.Name);
        
        await handler.HandleAsync(cmd);
    }

    internal ICommandHandler InvokeCommandHandler(string command)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(command, nameof(command));

        Type handler;
        if(!CommandDictionary.Items.TryGetValue(command, out handler))
        {
            throw new Exception($"THre is now command handler for {command} command.");
        }

        var handlerInstance = Activator.CreateInstance(handler) as ICommandHandler 
            ?? throw new Exception("Failed to create instance of ICommandHandler");
        
        return handlerInstance;
    }
}
