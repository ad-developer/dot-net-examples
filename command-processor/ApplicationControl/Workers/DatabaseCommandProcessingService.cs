using ApplicationControl.DbApplicationControl;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ApplicationControl.Workers;

public class DatabaseCommandProcessingService : BackgroundService
{
    private readonly ILogger<DatabaseCommandProcessingService> _logger;

    public IServiceProvider Services { get; }

    public DatabaseCommandProcessingService(IServiceProvider services, 
    ILogger<DatabaseCommandProcessingService> logger)
    {
        Services = services;
        _logger = logger;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
         _logger.LogInformation(
                "Database Command Processing Service is starting.");

        await DoWorkAsync(stoppingToken);
    }

    internal async Task DoWorkAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation(
            "Database Command Processing Service is working.");
        while(!stoppingToken.IsCancellationRequested)
        {
            using (var scope = Services.CreateScope())
            {
                var scopedProcessingService = 
                    scope.ServiceProvider
                        .GetRequiredService<IApplicationControlService>();

                await scopedProcessingService.ExcecuteNextCommandAsync(stoppingToken);
            }
            
            var delaySec = 5;             
            await Task.Delay(delaySec * 1000, stoppingToken);
        }
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation(
            "Database Command Processing Service is stopping.");

        await base.StopAsync(stoppingToken);
    }
}