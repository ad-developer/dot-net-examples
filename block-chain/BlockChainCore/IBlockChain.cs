namespace BlockChainCore;

public interface IBlockChain
{
    IReadOnlyList<IBlock> Blocks { get; }
    IBlock CreateBlock(string data);
    IBlock GetLatestBlock();
    void AddBlock(IBlock block);
    int ProofOfWork(int lastProof);
    bool IsValid();
}
