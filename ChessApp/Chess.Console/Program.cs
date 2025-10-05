using Chess.ConsoleUI;
using ChessLibrary;
using ChessLibrary.ChessPieces;
using System.Runtime.CompilerServices;

internal class Program
{
    public static string[,] board = new string[8, 8];
    private static void Main(string[] args)
    {
        Utilities.InitializePieces(board);
        ConsoleUtilities.PrintChessBoard(board);
        ConsoleUtilities.PlayGame(board);

    }

   




    //private static void Test()
    //{
    //    for (int i = 0; i < 8; i++)
    //    {

    //        for (int j = 0; j < 8; j++)
    //        {

    //            //(int fromRow, int fromCol, int toRow, int toCol) = UserInputValidation();

    //            if (MoveRook(0, 0, i, j) == false)
    //            {
    //                Console.WriteLine($"Invalid move row = {i} column = {j}");

    //            }
    //            else
    //            {
    //                Console.WriteLine($"Valid move row = {i} column = {j}");
    //                Console.WriteLine();
    //                PrintChessBoard();
    //                return;
    //            }
    //            Console.WriteLine();
    //            PrintChessBoard();

    //        }
    //    }


    //}
}

