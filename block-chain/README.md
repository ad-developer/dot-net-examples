# Basic Blockchain Example

This is an example of a basic blockchain implementation in .NET.

## Overview

A blockchain is a distributed database that maintains a continuously growing list of records, called blocks, which are linked and secured using cryptography.

## Features

- Simple blockchain structure
- Proof of Work (PoW) algorithm
- Basic transaction handling

## Getting Started

To get started with this example, clone the repository and build the project:

```sh
git clone https://github.com/yourusername/dot-net-examples.git
cd dot-net-examples/block-chain
dotnet build
```

## Usage

Run the application to see the blockchain in action:

```sh
dotnet run
```

## Example Code

Here is a snippet of the basic blockchain implementation:

```csharp
public class Block
{
    private int _index;
    public int Index => _index; 
    private  readonly DateTime _timestamp;
    public DateTime TimeStamp => _timestamp;
    private readonly string _data;
    public string Data => _data;
    private readonly string _previousHash;
    public string PreviousHash => _previousHash; 
    private readonly string _hash;
    public string Hash => _hash;
    private int _proof;
    public int Proof => _proof;

   public Block(int index, DateTime timestamp, string data, int proof,  string previousHash)
    {
        _index = index;
        _timestamp = timestamp;
        _data = data;
        _previousHash = previousHash;
        _proof = proof;
        _hash = CalculateHash();
    }

    public string CalculateHash()
    {
        var data = Encoding.UTF8.GetBytes($"{_index}{_timestamp}{_data}{_proof}{_previousHash}");
        using var sha256 = SHA256.Create();
        var hash = sha256.ComputeHash(data);
        return Convert.ToBase64String(hash);
    }
}
```


