using Chess.Console;

internal class Program
{
    public static string?[,] board = new string[8, 8];
    private static void Main(string[] args)
    {
        Utilities.InitializePieces(board);
    }

    public static void PrintChessBoard()
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

