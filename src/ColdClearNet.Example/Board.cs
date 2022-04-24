namespace ColdClearNet.Example;

public class Board
{
    //private bool[] _board = new bool[10 * 40];
    private BoardPiece[] _board = new BoardPiece[400];

    public Board()
    {
        for (int i = 0; i < 400; i++)
        {
            _board[i] = BoardPiece.None;
        }
    }

    public void Set(int x, int y, Piece piece)
    {
        _board[x + 10 * y] = (BoardPiece)(int) piece;
        CheckBoard();
    }

    private void SetUnchecked(int x, int y, Piece piece)
    {
        _board[x + 10 * y] = (BoardPiece)(int)piece;
    }

    public void Unset(int x, int y)
    {
        _board[x + 10 * y] = BoardPiece.None;
    }

    public void Print()
    {
        Console.Clear();

        for (int y = 39; y >= 0; y--)
        {
            for (int x = 0; x < 10; x++)
            {
                var t = _board[x + 10 * y];
                var symbol = GetPieceSymbol(t);
                Console.Write($"{symbol}");
            }

            Console.WriteLine();
        }
    }

    private char GetPieceSymbol(BoardPiece piece)
    {
        switch (piece)
        {
            case BoardPiece.I:
                return 'I';
            case BoardPiece.O:
                return 'O';
            case BoardPiece.T:
                return 'T';
            case BoardPiece.L:
                return 'L';
            case BoardPiece.J:
                return 'J';
            case BoardPiece.S:
                return 'S';
            case BoardPiece.Z:
                return 'Z';
            case BoardPiece.None:
                return '_';
            default:
                throw new ArgumentOutOfRangeException(nameof(piece), piece, null);
        }
    }

    private void CheckBoard()
    {
        for (int y = 0; y < 40; y++)
        {
            var gotLine = true;

            for (int x = 0; x < 10; x++)
            {
                if (_board[x + 10 * y] == BoardPiece.None)
                    gotLine = false;
            }

            if (gotLine)
            {
                for (int x = 0; x < 10; x++)
                {
                    Unset(x, y);
                }

                /*
                MoveRowDown(y +1);
                if (y > 0)
                    y--;*/
            }
        }
    }

    private void MoveRowDown(int y)
    {
        for (int x = 0; x < 10; x++)
        {
            if (y < 0)
                y = 0;
            if (y > 39)
                y = 39;

            Unset(x ,y);

            

            //SetUnchecked(x,  y);
        }
    }
}