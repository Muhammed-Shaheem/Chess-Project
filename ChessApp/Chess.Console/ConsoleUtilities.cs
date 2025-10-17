using ChessLibrary;
using System;

namespace Chess.ConsoleUI;


public static class ConsoleUtilities
{

    public static void PrintChessBoard(string[,] board)
    {

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (board[i, j] == null)
                {
                    Console.Write($"  | ");
                    continue;
                }
                Console.Write($"{board[i, j]}| ");


            }
            Console.WriteLine();
            Console.WriteLine("-------------------------------");

        }
    }

    public static (int, int, int, int, char) UserInputValidation(string[,] board, char turn)
    {
    FromRow:
        Console.WriteLine();
        Console.Write("Enter 'from row': ");
        if ((int.TryParse(Console.ReadLine(), out int fromRow) && Utilities.IsInsideBoard(fromRow)) == false)
        {
            Console.WriteLine("Invalid Input");
            goto FromRow;
        }

    FromCol:
        Console.Write("Enter 'from column': ");
        if ((int.TryParse(Console.ReadLine(), out int fromCol) && Utilities.IsInsideBoard(fromCol)) == false)
        {
            Console.WriteLine("Invalid Input");
            goto FromCol;
        }

        if (Utilities.HasPieceAt(board, fromRow-1, fromCol-1)) // the (-1) is for indexing because the parameter passed is not 0 based indexing 
        {
            //Ensure piece present
            Console.WriteLine("No piece selected to move.");
            goto FromRow;
        }

        char wOrB = board[fromRow - 1, fromCol - 1][0];
        if (wOrB != turn) // Ensure player moves their own piece
        {
            
            if (turn == 'W')
            {
                Console.WriteLine($"Cannot move black piece.Its white's turn.");
                goto FromRow;
            }
            else
            {
                Console.WriteLine($"Cannot move white piece.Its black's turn.");
                goto FromRow;
            }
        }

    ToRow:
        Console.Write("Enter to row: ");
        if ((int.TryParse(Console.ReadLine(), out int toRow) && Utilities.IsInsideBoard(toRow)) == false)
        {
            Console.WriteLine("Invalid Input");
            goto ToRow;

        }

    ToColumn:
        Console.Write("Enter to column: ");
        if ((int.TryParse(Console.ReadLine(), out int toCol) && Utilities.IsInsideBoard(toCol)) == false)
        {
            Console.WriteLine("Invalid Input");
            goto ToColumn;

        }

        char piece = board[fromRow - 1, fromCol - 1][1];
        return (fromRow - 1, fromCol - 1, toRow - 1, toCol - 1, piece);
    }

    public static void PlayGame(string[,] board)
    {
        char turn = 'W';
        bool isWinOrTie = false;

        while (isWinOrTie == false)
        {
        label:
            (int fromRow, int fromCol, int toRow, int toCol, char pieceMoved) = ConsoleUtilities.UserInputValidation(board, turn);
            bool isValidMove = Utilities.IsPieceToMoveValid(board, fromRow, fromCol, toRow, toCol);
            if (isValidMove == false)
            {
                Console.WriteLine("Invalid Move.");
                goto label;
            }

            turn = turn == 'B' ? 'W' : 'B';

            Console.WriteLine();
            ConsoleUtilities.PrintChessBoard(board);
        }
    }

}