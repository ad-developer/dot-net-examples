namespace blockchain;

public interface IBlock
{
    int Index { get; } 
    string PreviousHash { get; }
    string Hash { get; } 
    int Proof { get; }
    string CalculateHash();
}
