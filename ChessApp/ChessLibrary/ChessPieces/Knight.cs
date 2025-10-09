namespace ChessLibrary.ChessPieces;

public static class Knight
{
    public static bool Move(string[,] board, int fromRow, int fromCol, int toRow, int toCol)
    {
        if (board[toRow, toCol] != null && Utilities.IsSameColor(board[fromRow, fromCol], board[toRow, toCol]))
        {
            return false;
        }

        if (board[fromRow, fromCol] == "BN")
        {
            if ((((toRow == fromRow + 2) && toCol == fromCol + 1 || toCol == fromCol - 1) || ((toRow == fromRow - 2) && toCol == fromCol + 1 || toCol == fromCol - 1) || ((toRow == fromRow - 1) && toCol == fromCol + 2 || toCol == fromCol - 2) || ((toRow == fromRow + 1) && toCol == fromCol + 2 || toCol == fromCol - 2)) == false)
            {
                return false;
            }

            Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "BN");
            return true;
        }

        else if (board[fromRow, fromCol] == "WN")
        {
            if ((((toRow == fromRow + 2) && toCol == fromCol + 1 || toCol == fromCol - 1) || ((toRow == fromRow - 2) && toCol == fromCol + 1 || toCol == fromCol - 1) || ((toRow == fromRow - 1) && toCol == fromCol + 2 || toCol == fromCol - 2) || ((toRow == fromRow + 1) && toCol == fromCol + 2 || toCol == fromCol - 2)) == false)
            {
                return false;
            }

            Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "WN");
            return true;
        }
        return false;
    }
}
