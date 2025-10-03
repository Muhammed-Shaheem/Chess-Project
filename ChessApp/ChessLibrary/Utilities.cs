namespace ChessLibrary;

public static class Utilities
{
    public static void MovePiece(string[,] board, int fromRow, int fromCol, int toRow, int toCol, string piece)
    {
        board[toRow, toCol] = piece;
        board[fromRow, fromCol] = null;
    }
}
