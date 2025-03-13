using ApplicationControl;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args);
host.ConfigureServices((hostContext, services) =>
{
   services.AddApplicationControlCLI();  
});

var app = host.Build();
app.StartCLIMonitorLoop();

await app.StartAsync();

await app.WaitForShutdownAsync();