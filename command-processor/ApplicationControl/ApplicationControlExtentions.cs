using ApplicationControl.DbApplicationControl;
using ApplicationControl.Workers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ApplicationControl;

public static class ApplicationControlExtentions
{
    #region CLI
    public static IServiceCollection AddApplicationControlCLI(this IServiceCollection services){
        services.AddSingleton<CLILoop>();
        return services;
    }

    public static IHost StartCLIMonitorLoop(this IHost host)
    {
      var monitorLoop = host.Services.GetRequiredService<CLILoop>();
      monitorLoop.StartMonitorLoop();
      return host;
    }
    
    #endregion

    #region Dabatabse 

    public static IServiceCollection AddApplicationControlDatabase(this IServiceCollection services, string databaseConnection)
    {
        services.AddScoped<IApplicationControlContext, ApplicationControlContext>();
        services.AddDbContext<ApplicationControlContext>(options =>
        {
            options.UseSqlServer(databaseConnection);
        });
        
        services.AddScoped<IApplicationControlRepository, ApplicationControlRepository>();
        services.AddScoped<IApplicationControlService, ApplicationControlService>();
        services.AddHostedService<DatabaseCommandProcessingService>();
        
        return services;
    }
    #endregion
}