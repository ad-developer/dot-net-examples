namespace BlockChainCore;

public interface IBlock
{
    int Index { get; } 
    string PreviousHash { get; }
    DateTime TimeStamp { get; }
    string Data { get; }
    string Hash { get; } 
    int Proof { get; }
    string CalculateHash();
}
