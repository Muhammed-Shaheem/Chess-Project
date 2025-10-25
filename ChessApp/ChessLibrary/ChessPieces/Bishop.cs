
namespace ChessLibrary.ChessPieces;

public class Bishop
{
    public static bool Move(string[,] board, int fromRow, int fromCol, int toRow, int toCol)
    {

        if (board[toRow, toCol] != null && Utilities.IsSameColor(board[fromRow, fromCol], board[toRow, toCol]))
        {
            return false;
        }

        if (board[fromRow, fromCol] == "BB")
        {
            if ((Math.Abs(fromRow - toRow) == Math.Abs(fromCol - toCol)) == false)
            {
                return false;
            }

            if (IsPathClear(board, fromRow, fromCol, toRow, toCol) == false)
            {
                return false;
            }

            return true;



        }

        else if (board[fromRow, fromCol] == "WB")
        {
            if ((Math.Abs(fromRow - toRow) == Math.Abs(fromCol - toCol)) == false)
            {
                return false;
            }

            if (IsPathClear(board, fromRow, fromCol, toRow, toCol) == false)
            {
                return false;
            }

            return true;

        }

        return false;
    }

    public static bool IsPathClear(string[,] board, int fromRow, int fromCol, int toRow, int toCol)
    {

        int length = Math.Abs(fromRow - toRow);
        if (toRow > fromRow && toCol > fromCol)
        {
            for (int i = 1; i < length; i++)
            {
                if (board[fromRow + i, fromCol + i] != null)
                {
                    return false;
                }
            }
        }
        else if (toRow > fromRow && toCol < fromCol)
        {
            for (int i = 1; i < length; i++)
            {
                if (board[fromRow + i, fromCol - i] != null)
                {
                    return false;
                }
            }
        }

        else if (toRow < fromRow && toCol < fromCol)
        {
            for (int i = 1; i < length; i++)
            {
                if (board[fromRow - i, fromCol - i] != null)
                {
                    return false;
                }
            }
        }
        else if (toRow < fromRow && toCol > fromCol)
        {
            for (int i = 1; i < length; i++)
            {
                if (board[fromRow - i, fromCol + i] != null)
                {
                    return false;
                }
            }
        }


        return true;
    }
}
