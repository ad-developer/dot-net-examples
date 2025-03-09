namespace CommanProcessor;

public interface ICommandHandler
{
    public string Name { get; set; }
    Task HandleAsync(Command command);
}
