namespace ColdClearNet.Example;

public class ColdClearHandler : IDisposable
{
    private ColdClear? _coldClear;
    public bool IsStarted { get; private set; }
    
    public void Start(IEnumerable<Piece> queue, Options? options = null, Weights? weights = null)
    {
        if (IsStarted)
            throw new Exception("Bot is already started");
        
        Options opt;
        Weights wgt;
        
        if (options == null)
        {
            opt = ColdClearNet.ColdClear.DefaultOptions;
            opt.UseHold = true;
            opt.Speculate = true;
            opt.SpawnRule = SpawnRule.Row21AndFall;
            opt.MaxNodes = (uint)Math.Pow(2, 20);
        }
        else
        {
            opt = options.Value;
        }

        wgt = weights ?? ColdClearNet.ColdClear.DefaultWeights;

        _coldClear = new ColdClearNet.ColdClear(opt, wgt, null, queue);

        IsStarted = true;
    }
    
    public void Reset(bool[] board, int combo, bool b2b)
    {
        if (!IsStarted || _coldClear == null)
            throw new Exception("Bot is not started");

        _coldClear.Reset(board, combo, b2b);
    }

    public void Destroy()
    {
        Dispose();
    }

    public BotMove DoMove(int incomingGarbage)
    {
        if (!IsStarted || _coldClear == null)
            throw new Exception("Bot is not started");

        _coldClear.RequestNextMove(incomingGarbage);

        // TODO: Add async version
        var move = _coldClear.BlockNextMove();

        return move;
    }

    public void AddNewPiece(Piece piece)
    {
        if (!IsStarted || _coldClear == null)
            throw new Exception("Bot is not started");

        _coldClear.AddNextPieceAsync(piece);
    }

    public void Dispose()
    {
        _coldClear?.Dispose();
        _coldClear = null;
    }
}