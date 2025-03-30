using ApplicationControl;
using ApplicationControl.Workers;
using CommandProcessor.MicrosoftExtentionsDI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args);
host.ConfigureServices(static (hostContext, services) =>
{
   var dbConnection = hostContext.Configuration.GetConnectionString("DbConnection");
   
   services.AddCommandProcessor(p=>{
      p.RegisterServicesFromAssembly(typeof(CLILoop).Assembly);
   });
   services.AddApplicationControlCLI();  
   if (dbConnection is null)
   {
      throw new ArgumentNullException("DbConnection", "DbConnection is not set in appsettings.json");
   }
   services.AddApplicationControlDatabase(dbConnection);
});

var app = host.Build();
app.StartCLIMonitorLoop();

await app.StartAsync();

await app.WaitForShutdownAsync();