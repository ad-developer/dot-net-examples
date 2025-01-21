using System.Security.Cryptography;
using System.Text;
using BlockChainCore;


/// <summary>
/// Represents a block in the blockchain.
/// </summary>
public class Block : IBlock
{
    /// <summary>
    /// Gets the index of the block.
    /// </summary>
    private int _index;
    public int Index => _index;

    /// <summary>
    /// Gets the timestamp of the block.
    /// </summary>
    private readonly DateTime _timestamp;
    public DateTime TimeStamp => _timestamp;

    /// <summary>
    /// Gets the data stored in the block.
    /// </summary>
    private readonly string _data;
    public string Data => _data;

    /// <summary>
    /// Gets the hash of the previous block.
    /// </summary>
    private readonly string _previousHash;
    public string PreviousHash => _previousHash;

    /// <summary>
    /// Gets the hash of the current block.
    /// </summary>
    private readonly string _hash;
    public string Hash => _hash;

    /// <summary>
    /// Gets the proof of work for the block.
    /// </summary>
    private int _proof;
    public int Proof => _proof;

    /// <summary>
    /// Initializes a new instance of the <see cref="Block"/> class.
    /// </summary>
    /// <param name="index">The index of the block.</param>
    /// <param name="timestamp">The timestamp of the block.</param>
    /// <param name="data">The data stored in the block.</param>
    /// <param name="proof">The proof of work for the block.</param>
    /// <param name="previousHash">The hash of the previous block.</param>
    public Block(int index, DateTime timestamp, string data, int proof, string previousHash)
    {
        _index = index;
        _timestamp = timestamp;
        _data = data;
        _previousHash = previousHash;
        _proof = proof;
        _hash = CalculateHash();
    }

    /// <summary>
    /// Calculates the hash of the block.
    /// </summary>
    /// <returns>The hash of the block as a base64 string.</returns>
    public string CalculateHash()
    {
        var data = Encoding.UTF8.GetBytes($"{_index}{_timestamp}{_data}{_proof}{_previousHash}");
        using var sha256 = SHA256.Create();
        var hash = sha256.ComputeHash(data);
        return Convert.ToBase64String(hash);
    }
}
