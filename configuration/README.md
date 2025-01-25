# Configuration Example using IOptions, IOptionsSnapshot, and IOptionsMonitor

This example demonstrates how to use `IOptions`, `IOptionsSnapshot`, and `IOptionsMonitor` in a .NET application for configuration management.

## IOptions
`IOptions<T>` is used to retrieve configuration values. It is a singleton and provides a way to access configuration settings that do not change after the application starts.

## IOptionsSnapshot
`IOptionsSnapshot<T>` is a scoped service and provides a way to access configuration settings that can change during the application's lifetime. It is useful in scenarios where you need to reload configuration settings without restarting the application.

## IOptionsMonitor
`IOptionsMonitor<T>` is a singleton service that provides notifications when configuration settings change. It is useful for reacting to configuration changes dynamically.

## Example Usage

This example shows how to configure and use `IOptions`, `IOptionsSnapshot`, and `IOptionsMonitor` to manage application settings effectively.