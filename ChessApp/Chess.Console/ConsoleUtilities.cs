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

    public static (int, int, int, int,char) UserInputValidation(string[,] board, char turn)
    {


    FromRow:
        Console.WriteLine();
        Console.Write("Enter from row: ");
        if ((int.TryParse(Console.ReadLine(), out int fromRow) && (fromRow > 0 && fromRow < 9)) == false)
        {
            Console.WriteLine("Invalid Input");
            goto FromRow;
        }

    FromCol:
        Console.Write("Enter from column: ");
        if ((int.TryParse(Console.ReadLine(), out int fromCol) && (fromCol > 0 && fromCol < 9)) == false)
        {
            Console.WriteLine("Invalid Input");
            goto FromCol;
        }

        char? wOrB = board[fromRow - 1, fromCol - 1]?[0];
        if (wOrB == null || wOrB != turn)
        {
            if (turn == 'W')
            {
                Console.WriteLine($"Its white turn.");
                goto FromRow;
            }
            else
            {
                Console.WriteLine($"Its black turn.");
                goto FromRow;
            }
        }
      

    ToRow:
        Console.Write("Enter to row: ");
        if ((int.TryParse(Console.ReadLine(), out int toRow) && (toRow > 0 && toRow < 9)) == false)
        {
            Console.WriteLine("Invalid Input");
            goto ToRow;

        }

    ToColumn:
        Console.Write("Enter to column: ");
        if ((int.TryParse(Console.ReadLine(), out int toCol) && (toCol > 0 && toCol < 9)) == false)
        {
            Console.WriteLine("Invalid Input");
            goto ToColumn;

        }

        char piece = board[fromRow - 1, fromCol - 1][1];
        return (fromRow - 1, fromCol - 1, toRow - 1, toCol - 1,piece);
    }

}