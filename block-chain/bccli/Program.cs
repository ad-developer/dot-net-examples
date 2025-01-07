using bccli;
using BlockChainCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

var services = new ServiceCollection();
services.AddSingleton<IBlockChain, BlockChain>();

var serviceProvider = services.BuildServiceProvider();
var blockChain = serviceProvider.GetRequiredService<IBlockChain>();

CancellationTokenSource _cancelTokenSrc = new CancellationTokenSource();


// CTL + C is the built-in cancellation for console apps; 
Console.CancelKeyPress += (sender, e) =>
{
    e.Cancel = true;
    Console.WriteLine("Exiting...");
    Environment.Exit(0);
};
CancellationToken cancelToken = _cancelTokenSrc.Token;

Console.WriteLine("Type commands followed by 'ENTER'");
Console.WriteLine("Press CTL+C to Terminate");
Console.WriteLine();

try
{
    await Task.Run(() =>
    {
        while (true)
        {
            string? command = Console.ReadLine();
            if (string.IsNullOrEmpty(command))
            {
                continue;
            }
            if (command.StartsWith("add", StringComparison.OrdinalIgnoreCase))
            {
                var args = command.SplitOutsideQuotes(' ',true,true, false);
                if(args.Length < 2)
                {
                    Console.WriteLine("Please provide data to add");
                    continue;
                }
                
                var data = args[1];
                Console.WriteLine($"Adding: {data}");
                var newBlock = blockChain.CreateBlock(data);

                Console.WriteLine("Block added");
                var newBlockJson = JsonSerializer.Serialize(newBlock, new JsonSerializerOptions { WriteIndented = true });
                
                Console.WriteLine(newBlockJson);
                continue;
            }
            if (command.Equals("showchain", StringComparison.OrdinalIgnoreCase))
            {
                var blocks = blockChain.Blocks;
                var lastJson = JsonSerializer.Serialize(blocks, new JsonSerializerOptions { WriteIndented = true });
                Console.WriteLine(lastJson);
                continue;
            }
            if (command.Equals("showlast", StringComparison.OrdinalIgnoreCase))
            {
                var lastBlock = blockChain.GetLatestBlock();
                var lastJson = JsonSerializer.Serialize(lastBlock, new JsonSerializerOptions { WriteIndented = true });
                Console.WriteLine(lastJson);
                continue;
            }
            if (command.ToLower() == "clear")
            {
                Console.Clear();
                continue;
            }
            if (command.ToLower() == "help")
            {
                Console.WriteLine("Commands: ");
                Console.WriteLine("add 'item to add' - add a new block to the chain");
                Console.WriteLine("showchain - to exit");
                Console.WriteLine("showlast - to display the last block");
                Console.WriteLine("clear - to clear the console");
                Console.WriteLine("help - to display this message");
                continue;
            }
            Console.WriteLine($"Command: {command}");
        }
    }, cancelToken);   

    // Continue listening until cancel signal is sent
    cancelToken.WaitHandle.WaitOne();
    cancelToken.ThrowIfCancellationRequested();
}
catch (OperationCanceledException)
{
    Console.WriteLine("Operation Cancelled");
}   
catch (Exception ex)
{
    
    Console.WriteLine($"Error: {ex.Message}");;
}