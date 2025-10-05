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




}