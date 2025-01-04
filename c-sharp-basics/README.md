# C# .NET 9 Cheat Sheet

## Table of Contents
1. [Introduction](#introduction)
2. [Basic Syntax](#basic-syntax)
3. [Data Types](#data-types)
4. [Control Structures](#control-structures)
5. [Classes and Objects](#classes-and-objects)
6. [LINQ](#linq)
7. [Asynchronous Programming](#asynchronous-programming)
8. [New Features in .NET 9](#new-features-in-net-9)

## Introduction
C# is a modern, object-oriented programming language developed by Microsoft. .NET 9 is the latest version of the .NET framework, which includes many new features and improvements.

## Basic Syntax
```csharp
using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
```

## Data Types
- **int**: Integer type
- **double**: Double-precision floating point
- **char**: Character type
- **string**: Sequence of characters
- **bool**: Boolean type

## Control Structures
### If-Else
```csharp
if (condition)
{
    // code to execute if condition is true
}
else
{
    // code to execute if condition is false
}
```

### Switch
```csharp
switch (variable)
{
    case value1:
        // code to execute if variable == value1
        break;
    case value2:
        // code to execute if variable == value2
        break;
    default:
        // code to execute if variable doesn't match any case
        break;
}
```

### Loops
#### For Loop
```csharp
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
}
```

#### While Loop
```csharp
int i = 0;
while (i < 10)
{
    Console.WriteLine(i);
    i++;
}
```

## Classes and Objects
### Defining a Class
```csharp
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public void Greet()
    {
        Console.WriteLine($"Hello, my name is {Name}.");
    }
}
```

### Creating an Object
```csharp
Person person = new Person();
person.Name = "John";
person.Age = 30;
person.Greet();
```

## LINQ
### Basic LINQ Query
```csharp
int[] numbers = { 1, 2, 3, 4, 5 };
var evenNumbers = from num in numbers
                  where num % 2 == 0
                  select num;

foreach (var num in evenNumbers)
{
    Console.WriteLine(num);
}
```

## Asynchronous Programming
### Async and Await
```csharp
public async Task<string> GetDataAsync()
{
    await Task.Delay(1000); // Simulate a delay
    return "Data received";
}

public async void CallGetDataAsync()
{
    string data = await GetDataAsync();
    Console.WriteLine(data);
}
```

## New Features in .NET 9
- **Records**: Immutable data types
- **Init-only setters**: Properties that can only be set during object initialization
- **Top-level statements**: Simplified program structure
- **Pattern matching enhancements**: Improved pattern matching capabilities

### Records
```csharp
public record Person(string Name, int Age);
```

### Init-only Setters
```csharp
public class Person
{
    public string Name { get; init; }
    public int Age { get; init; }
}
```

### Top-level Statements
```csharp
using System;

Console.WriteLine("Hello, World!");
```

### Pattern Matching Enhancements
```csharp
object obj = "Hello";
if (obj is string s)
{
    Console.WriteLine(s.ToUpper());
}
```
