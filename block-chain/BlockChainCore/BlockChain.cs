using System.Security.Cryptography;
using System.Text;

namespace BlockChainCore;

public class BlockChain : IBlockChain
{
    private readonly List<IBlock> _blocks = new();
    public IReadOnlyList<IBlock> Blocks => _blocks;

    public BlockChain()
    {   
        // Create the genesis block
        _blocks.Add(new Block(0, DateTime.Now, "Genesis Block", 1, "0"));
    }

    public IBlock GetLatestBlock()
    {
        return _blocks.Last();
    }
    
    public IBlock CreateBlock(string data)
    {
        var previousBlock = GetLatestBlock();
        var proof = ProofOfWork(previousBlock.Proof);
        var block = new Block(previousBlock.Index + 1, DateTime.Now, data, proof,  previousBlock.Hash);
        _blocks.Add(block);
        return block;
    }
    
    public void AddBlock(IBlock block)
    {
        var previousBlock = _blocks.Last();
        if (block.PreviousHash != previousBlock.Hash)
        {
            throw new InvalidOperationException("Invalid block");
        }

        _blocks.Add(block);
    }

    public int ProofOfWork(int lastProof)
    {
        var proof = 0;
        var chaeckProof = false;
        
        while (!chaeckProof)
        {
            var hashOperation = SHA256.Create();
            var hashOperationBytes = hashOperation.ComputeHash(Encoding.UTF8.GetBytes((proof * proof - lastProof * lastProof).ToString()));
            var hash = BitConverter.ToString(hashOperationBytes).Replace("-", "").ToLower();
            if (hash.StartsWith("0000"))
            {
                chaeckProof = true;
            }
            else
            {
                proof++;
            }
        }

        return proof;
    }
    public bool IsValid()
    {
        for (var i = 1; i < _blocks.Count; i++)
        {
            var currentBlock = _blocks[i];
            var previousBlock = _blocks[i - 1];

            if (currentBlock.Hash != currentBlock.CalculateHash())
            {
                return false;
            }

            if (currentBlock.PreviousHash != previousBlock.Hash)
            {
                return false;
            }
        }

        return true;
    }

}
