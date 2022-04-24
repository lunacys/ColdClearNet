namespace ColdClearNet;

public sealed class ColdClear : IDisposable
{
    private IntPtr _bot;
    private static Options? _defaultOptions;
    private static Weights? _defaultWeights;

    public static Options DefaultOptions
    {
        get
        {
            if (_defaultOptions == null)
            {
                _defaultOptions = new Options();
                ColdClearInterop.DefaultOptions(_defaultOptions);
            }

            return _defaultOptions;
        }
    }

    public static Weights DefaultWeights
    {
        get
        {
            if (_defaultWeights == null)
            {
                _defaultWeights = new Weights();
                ColdClearInterop.DefaultWeights(_defaultWeights);
            }

            return _defaultWeights;
        }
    }

    public ColdClear() 
        : this(DefaultOptions, DefaultWeights) { }

    public ColdClear(Options options, Weights weights)
        : this(options, weights, book: null) { }

    public ColdClear(Options options, Weights weights, Book? book)
        : this(options, weights, book, null) { }

    public ColdClear(Options options, Weights weights, IEnumerable<Piece>? queue)
        : this(options, weights, null, queue) { }

    public ColdClear(Options options, Weights weights, Book? book, IEnumerable<Piece>? queue)
    {
        var queueArr = queue?.ToArray();

        _bot = ColdClearInterop.LaunchAsync(options, weights, book?._book ?? IntPtr.Zero,
            queueArr == null ? Array.Empty<Piece>() : queueArr, queueArr == null ? 0U : (uint)queueArr.Length);
    }

    public ColdClear(
        Options options, 
        Weights weights, 
        Book book, 
        bool[] field,
        int bagRemain,
        ref Piece hold, 
        bool backToBack = false, 
        int combo = 0, 
        IEnumerable<Piece>? queue = null
        )
    {
        var queueArr = queue?.ToArray();

        _bot = ColdClearInterop.LaunchWithBoardAsync(
            options, weights, book._book,
            field.Select(b => b ? (byte)1 : (byte)0).ToArray(),
            (uint)bagRemain, ref hold, backToBack, (uint)combo,
            queueArr == null ? Array.Empty<Piece>() : queueArr,
            queueArr == null ? 0U : (uint)queueArr.Length
        );
    }

    public async Task AddNextPieceAsync(Piece piece)
    {
        await Task.Run(() =>
        {
            ColdClearInterop.AddNextPieceAsync(_bot, piece);
        });
    }

    public void RequestNextMove(int incomingGarbage)
    {
        ColdClearInterop.RequestNextMove(_bot, (uint) incomingGarbage);
    }

    public BotPollStatus PollNextMove(out Move move, out PlanPlacement[] plan)
    {
        move = new Move();
        var planLength = 32U;
        plan = new PlanPlacement[planLength];
        var status = ColdClearInterop.PollNextMove(_bot, move, plan, ref planLength);
        plan = plan.Take((int)planLength).ToArray();
        return status;
    }

    public async Task<(Move move, PlanPlacement[] plan)?> NextMoveAsync(int incomingGarbage)
    {
        return await Task.Run(() =>
        {
            RequestNextMove(incomingGarbage);

            var move = new Move();
            var planLength = 32U;
            var plan = new PlanPlacement[planLength];
            var status = ColdClearInterop.BlockNextMove(_bot, move, plan, ref planLength);

            if (status == BotPollStatus.MoveProvided)
                return (move, plan.Take((int)planLength).ToArray());
            
            return ((Move, PlanPlacement[])?)null;
        });
    }

    public void Reset(bool[] board, int combo, bool backToBack)
    {
        ColdClearInterop.ResetAsync(_bot, board.Select(b => b ? (byte)1 : (byte)0).ToArray(), backToBack, (uint) combo);
    }

    private void ReleaseUnmanagedResources()
    {
        if (_bot == IntPtr.Zero)
            return;

        ColdClearInterop.DestroyAsync(_bot);
        _bot = IntPtr.Zero;
    }

    public void Dispose()
    {
        ReleaseUnmanagedResources();
        GC.SuppressFinalize(this);
    }

    ~ColdClear()
    {
        ReleaseUnmanagedResources();
    }
}