using ConfigurtionExampleWebAPI;
using Microsoft.Extensions.Options;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.Configure<CustomOption>(builder.Configuration.GetSection("CustomOption"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
     app.MapScalarApiReference(options =>
    {
        options.WithTitle("Configuration WebAPI")
            .WithTheme(ScalarTheme.Mars)
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
            
    });
}

app.UseHttpsRedirection();

// Confgure endpoints
// IConfiguration allows a hot reload of the configuration
app.MapGet("/GetConfigRaw", (IConfiguration configuration) =>
{
    return configuration["OptionOne"];
});

// IOptions buils an instance of the configuration and does not allow hot reload
// IOptions is injected as a singleton.
app.MapGet("/GetConfigCustomOption", (IOptions<CustomOption> options) =>
{
    return options.Value;
});

// IOptionsSnapshot allows a hot reload of the configuration. It is useful when the configuration is changed at runtime.
// The snapshot is injectd withing the scope of the request. Scoped services can be injected with IOptionsSnapshot.
app.MapGet("/GetConfigCustomOptionSnapshot", (IOptionsSnapshot<CustomOption> options) =>
{
    return options.Value;
});

// IOptionsMonitor allows a hot reload of the configuration. It is useful when the configuration is changed at runtime.
// The monitor monitor allows to be changed during the request. It is injected as a transient.
app.MapGet("/GetConfigCustomOptionMonitor", (IOptionsMonitor<CustomOption> options) =>
{
    return options.CurrentValue;
});

app.Run();
