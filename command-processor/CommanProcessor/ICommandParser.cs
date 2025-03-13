namespace CommandProcessor;

public interface ICommandParser
{
    Task<Command> ParseAsync(string command);
}
