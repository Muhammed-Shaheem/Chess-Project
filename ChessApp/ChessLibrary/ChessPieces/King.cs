
namespace ChessLibrary.ChessPieces;

public class King
{
    public static bool Move(string[,] board, int fromRow, int fromCol, int toRow, int toCol)
    {
        if (board[toRow, toCol] != null && Utilities.IsSameColor(board[fromRow, fromCol], board[toRow, toCol]))
        {
            return false;
        }

        if (board[fromRow, fromCol] == "BK")
        {
            if (((toRow == fromRow + 1 && (toCol == fromCol || toCol == fromCol + 1 || toCol == fromRow - 1)) || (toRow == fromRow - 1 && (toCol == fromCol || toCol == fromCol + 1 || toCol == fromRow - 1))) == false)
            {
                return false;
            }
            Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "BK");
            return true;
        }

        else if (board[fromRow, fromCol] == "WK")
        {
            if (((toRow == fromRow + 1 && (toCol == fromCol || toCol == fromCol + 1 || toCol == fromRow - 1)) || (toRow == fromRow - 1 && (toCol == fromCol || toCol == fromCol + 1 || toCol == fromRow - 1))) == false)
            {
                return false;
            }
            Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "WK");
            return true;
        }

        return true;
    }
}
