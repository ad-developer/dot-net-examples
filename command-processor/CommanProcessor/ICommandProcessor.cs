namespace CommandProcessor;

public interface ICommandProcessor
{
    Task PprocessAsync(string command);
}
