using CommandProcessor;

namespace ApplicationControl.Handlers;

[Command("test")]
public class TestCommandHandler : ICommandHandler
{
    public IServiceProvider Services { get; }

    public TestCommandHandler(IServiceProvider services)
    {
        Services = services;
    }
    public async Task HandleAsync(Command command)
    {
        Console.WriteLine("TestCommandHandler command excecuted ");
        Console.WriteLine(string.Empty);
       
        await Task.Delay(0);
    }
}
