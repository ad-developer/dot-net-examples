namespace CommanProcessor;

public interface ICommandProcessor
{
    Task PprocessAsync(string command);
}
