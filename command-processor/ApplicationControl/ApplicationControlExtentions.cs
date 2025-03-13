using ApplicationControl.Workers;
using CommandProcessor.MicrosoftExtentionsDI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ApplicationControl;

public static class ApplicationControlExtentions
{
    #region CLI
    public static IServiceCollection AddApplicationControlCLI(this IServiceCollection services){

        services.AddCommandProcessor(p=>{
            p.RegisterServicesFromAssembly(typeof(CLILoop).Assembly);
        });
        services.AddSingleton<CLILoop>();
        return services;
    }

    public static IHost StartCLIMonitorLoop(this IHost host){

      var monitorLoop = host.Services.GetRequiredService<CLILoop>();
      monitorLoop.StartMonitorLoop();
      return host;
    }
    
    #endregion

    #region Dabatabse 
    
    #endregion
}