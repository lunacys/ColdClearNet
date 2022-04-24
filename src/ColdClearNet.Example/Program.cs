using System.Runtime.InteropServices;

namespace ColdClearNet.Example;

class Program
{
    public static void Main(string[] args)
    {
        /*Task t = Task.Run(() =>
        {
            var book = IntPtr.Zero;
            var piece = Piece.I;
            var count = 1;

            var defaultWeights = new Weights();
            ColdClearInterop.DefaultWeights(defaultWeights);

            var defaultOptions = new Options();
            ColdClearInterop.DefaultOptions(defaultOptions);

            Console.WriteLine("Launching bot...");
            var bot = ColdClearInterop.LaunchAsync(defaultOptions, defaultWeights, book, ref piece, 0);

            Console.WriteLine("Adding I pieces");
            ColdClearInterop.AddNextPieceAsync(bot, Piece.I);
            ColdClearInterop.AddNextPieceAsync(bot, Piece.J);
            ColdClearInterop.AddNextPieceAsync(bot, Piece.L);
            ColdClearInterop.AddNextPieceAsync(bot, Piece.Z);
            ColdClearInterop.AddNextPieceAsync(bot, Piece.S);
            ColdClearInterop.AddNextPieceAsync(bot, Piece.O);
            ColdClearInterop.AddNextPieceAsync(bot, Piece.I);
            ColdClearInterop.AddNextPieceAsync(bot, Piece.S);
            ColdClearInterop.AddNextPieceAsync(bot, Piece.Z);
            ColdClearInterop.AddNextPieceAsync(bot, Piece.S);


            Console.WriteLine("Requesting next move");
            ColdClearInterop.RequestNextMove(bot, 0);
            var move = new Move()
            { };
            PlanPlacement[] planPlacement = new PlanPlacement[10];
            uint planLength = 0;
            Console.WriteLine("Polling next move");
            var result = ColdClearInterop.BlockNextMove(bot, move, planPlacement, ref planLength);
            ColdClearInterop.RequestNextMove(bot, 0);
            var result1 = ColdClearInterop.BlockNextMove(bot, move, planPlacement, ref planLength);
            ColdClearInterop.RequestNextMove(bot, 1);
            var result2 = ColdClearInterop.BlockNextMove(bot, move, planPlacement, ref planLength);
            ColdClearInterop.RequestNextMove(bot, 2);
            var result3 = ColdClearInterop.BlockNextMove(bot, move, planPlacement, ref planLength);
            ColdClearInterop.RequestNextMove(bot, 3);
            var result4 = ColdClearInterop.BlockNextMove(bot, move, planPlacement, ref planLength);
            ColdClearInterop.RequestNextMove(bot, 4);
            var result5 = ColdClearInterop.BlockNextMove(bot, move, planPlacement, ref planLength);
            ColdClearInterop.RequestNextMove(bot, 5);
            var result6 = ColdClearInterop.BlockNextMove(bot, move, planPlacement, ref planLength);
            ColdClearInterop.RequestNextMove(bot, 6);
            var result7 = ColdClearInterop.BlockNextMove(bot, move, planPlacement, ref planLength);


            Console.WriteLine("Destroying the bot");
            ColdClearInterop.DestroyAsync(bot);
        });

        await t;*/
    }
}