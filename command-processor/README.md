# Command Processor

The `command-processor` project is a .NET-based implementation designed to handle application commands in a structured and extensible way. It provides a framework for processing commands via different input sources, such as CLI or a database, enabling centralized control and execution of application logic.

## Key Features
- **Command Abstraction**: Define commands as discrete units of work.
- **Input Flexibility**: Accept commands from CLI or database sources.
- **Extensibility**: Easily add new commands or input sources.

## Example Usage

### 1. Using CLI
```bash
dotnet run --command "CreateUser" --parameters "username=JohnDoe;email=john@example.com"
```

### 2. Using Database
Commands can be stored in a database table and processed in batches:
```sql
INSERT INTO Commands (CommandName, Parameters) 
VALUES ('CreateUser', 'username=JaneDoe;email=jane@example.com');
```

The application can then fetch and execute these commands:
```csharp
var commands = commandProcessor.FetchFromDatabase();
commandProcessor.Execute(commands);
```

## How It Works
1. **Command Definition**: Define commands as classes implementing a common interface, e.g., `ICommand`.
2. **Command Parsing**: Parse input (CLI arguments or database rows) into command objects.
3. **Command Execution**: Execute commands using a centralized processor.

This design ensures a clean separation of concerns and simplifies the addition of new commands or input methods.