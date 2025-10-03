using System;

namespace Chess.Console;


public static class Utilities
{
    public static void InitializePieces(string[,] board)
    {
        board[0, 0] = "BR"; // Rook
        board[0, 1] = "BN"; // Knight
        board[0, 2] = "BB"; // Bishop
        board[0, 3] = "BQ"; // Queen
        board[0, 4] = "BK"; // King
        board[0, 5] = "BB";
        board[0, 6] = "BN";
        board[0, 7] = "BR";

        board[7, 0] = "WR"; // Rook
        board[7, 1] = "WN"; // Knight
        board[7, 2] = "WB"; // Bishop
        board[7, 3] = "WQ"; // Queen
        board[7, 4] = "WK"; // King
        board[7, 5] = "WB";
        board[7, 6] = "WN";
        board[7, 7] = "WR";

        for (int i = 0; i < 8; i++)
        {
            board[1, i] = "BP";
            board[6, i] = "WP";
        }
    }

 
}