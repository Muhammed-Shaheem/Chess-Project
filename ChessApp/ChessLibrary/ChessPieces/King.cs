
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
            if (((toRow == fromRow + 1 && (toCol == fromCol || toCol == fromCol + 1 || toCol == fromCol - 1)) || (toRow == fromRow - 1 && (toCol == fromCol || toCol == fromCol + 1 || toCol == fromCol - 1)) || (toRow == fromRow && (toCol == fromCol + 1 || toCol == fromCol - 1))) == false)
            {
                return false;
            }
            return true;
        }

        else if (board[fromRow, fromCol] == "WK")
        {
            if (((toRow == fromRow + 1 && (toCol == fromCol || toCol == fromCol + 1 || toCol == fromCol - 1)) || (toRow == fromRow - 1 && (toCol == fromCol || toCol == fromCol + 1 || toCol == fromCol - 1)) || (toRow == fromRow && (toCol == fromCol + 1 || toCol == fromCol - 1))) == false)
            {
                return false;
            }
            return true;
        }

        return true;
    }
}
