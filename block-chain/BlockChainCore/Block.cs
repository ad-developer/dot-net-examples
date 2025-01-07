using System.Security.Cryptography;
using System.Text;

namespace BlockChainCore;

public class Block : IBlock
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
