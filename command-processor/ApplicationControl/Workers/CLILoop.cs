using CommandProcessor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ApplicationControl.Workers;

public class CLILoop
{
    private readonly ILogger _logger;
    private readonly CancellationToken _cancellationToken;
    public IServiceProvider Services { get; }
   
    public CLILoop(ILogger<CLILoop> logger, IHostApplicationLifetime applicationLifetime, IServiceProvider services)
    {
        _logger = logger;
        _cancellationToken = applicationLifetime.ApplicationStopping;
        Services = services;
    }

    public void StartMonitorLoop()
    {
        _logger.LogInformation("CLILoop Loop is starting.");

        // Run a console user input loop in a background thread
        Task.Run(async () => await MonitorAsync());
    }

    private async ValueTask MonitorAsync()
    {
        while (!_cancellationToken.IsCancellationRequested)
        {
            try{
                var commnad = Console.ReadLine();
                _logger.LogInformation($"Command {commnad} entered");
                
                if(!string.IsNullOrEmpty(commnad))
                {
                    using var scope = Services.CreateScope();
                    var scopedProcessingService =
                        scope.ServiceProvider
                            .GetRequiredService<ICommandProcessor>();

                    await scopedProcessingService.PprocessAsync(commnad);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}