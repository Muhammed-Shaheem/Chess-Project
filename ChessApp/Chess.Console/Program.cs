using Chess.ConsoleUI;
using ChessLibrary;

internal class Program
{
    public static string?[,] board = new string[8, 8];
    private static void Main(string[] args)
    {
        Utilities.InitializePieces(board);
        ConsoleUtilities.PrintChessBoard(board);
    }

}

