namespace ChessLibrary.ChessPieces;

public static class Knight
{
    public static bool Move(string[,] board, int fromRow, int fromCol, int toRow, int toCol)
    {
        if (board[fromRow, fromCol] == "BN")
        {
            if (board[toRow, toCol] == null)
            {
                if (board[toRow, toCol] != null)
                {
                    // if the piece in the target is black or opponet king then return false
                    char? firstChar = board[toRow, toCol]![0];
                    if (firstChar == 'B')
                    {
                        return false;
                    }
                    else if (board[toRow, toCol] == "Wk")
                    {
                        return false;
                    }
                    else
                    {
                        Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "BN");

                        return true;
                    }
                }
                if (((toRow == fromRow + 2) && toCol == fromCol + 1 || toCol == fromCol - 1) || ((toRow == fromRow - 2) && toCol == fromCol + 1 || toCol == fromCol - 1))
                {
                    Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "BN");
                    return true;
                }

            }
            else if (board[toRow, toCol] != null)
            {

            }
        }

        if (board[fromRow, fromCol] == "WN")
        {
            if (((toRow == fromRow + 2) && toCol == fromCol + 1 || toCol == fromCol - 1) || ((toRow == fromRow - 2) && toCol == fromCol + 1 || toCol == fromCol - 1))
            {
                Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "BN");
                return true;
            }
        }
        return false;
    }
}
