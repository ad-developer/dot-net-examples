namespace CommanProcessor;

public interface ICommandParser
{
    Task<Command> ParseAsync(string command);
}
