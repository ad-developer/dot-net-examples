using console_app_with_dependency_injection;
using Microsoft.Extensions.DependencyInjection;

/// Create a service collection

        var services = new ServiceCollection();

        // Register the calculator service
        services.AddSingleton<ICalculator, Calculator>(); 

        // Build the service provider
        var serviceProvider = services.BuildServiceProvider();

        // Get the calculator instance using the service provider
        var calculator = serviceProvider.GetRequiredService<ICalculator>();
        
        // Use the calculator
        Console.WriteLine(calculator.Add(5, 3)); // Output: 8