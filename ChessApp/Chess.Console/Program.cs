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
        PlayGame();

    }

    private static void PlayGame()
    {
        char turn = 'W';
        bool isWinOrTie = false;

        while (isWinOrTie == false)
        {
            (int fromRow, int fromCol, int toRow, int toCol, char pieceMoved) = ConsoleUtilities.UserInputValidation(board, turn);
            bool isValidMove = IsValidMove(fromRow, fromCol, toRow, toCol, pieceMoved);
            if (isValidMove == false)
            {
                Console.WriteLine("Invalid Move.");
            }
            if (turn == 'W')
            {
                turn = 'B';
            }
            else
            {
                turn = 'W';
            }
            Console.WriteLine();
            ConsoleUtilities.PrintChessBoard(board);
        }
    }

    private static bool IsValidMove(int fromRow, int fromCol, int toRow, int toCol, char pieceMoved)
    {
        bool isValidMove = false;
        switch (pieceMoved)
        {
            case 'P':
                isValidMove = Pawn.Move(board, fromRow, fromCol, toRow, toCol);
                break;
            case 'R':
                isValidMove = Rook.Move(board, fromRow, fromCol, toRow, toCol);
                break;
            case 'N':
                isValidMove = Knight.Move(board, fromRow, fromCol, toRow, toCol);
                break;
            case 'B':
                isValidMove = Bishop.Move(board, fromRow, fromCol, toRow, toCol);
                break;
            case 'Q':
                isValidMove = Queen.Move(board, fromRow, fromCol, toRow, toCol);
                break;
            case 'K':
                isValidMove = King.Move(board, fromRow, fromCol, toRow, toCol);
                break;

            default:
                break;
        }

        return isValidMove;
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

