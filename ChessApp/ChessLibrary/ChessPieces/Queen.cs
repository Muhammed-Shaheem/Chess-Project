
namespace ChessLibrary.ChessPieces;

public class Queen
{
    public static bool Move(string[,] board, int fromRow, int fromCol, int toRow, int toCol)
    {
        if (board[toRow, toCol] != null && Utilities.IsSameColor(board[fromRow, fromCol], board[toRow, toCol]))
        {
            return false;


        }

        if (board[fromRow, fromCol] == "BQ")
        {
            if (((fromRow == toRow || fromCol == toCol) || (Math.Abs(fromRow - toRow) == Math.Abs(fromCol - toCol))) == false)
            {
                return false;
            }


            if (IsPathClear(board, fromRow, fromCol, toRow, toCol) == false)
            {
                return false;
            }

            //if (Utilities.IsKingSafe(board, fromRow, fromCol, toRow, toCol) == false)
            //{
            //    return false;
            //}

            return true;



        }

        else if (board[fromRow, fromCol] == "WQ")
        {
            if (((fromRow == toRow || fromCol == toCol) || (Math.Abs(fromRow - toRow) == Math.Abs(fromCol - toCol))) == false)
            {
                return false;
            }


            if (IsPathClear(board, fromRow, fromCol, toRow, toCol) == false)
            {
                return false;
            }

            //if (Utilities.IsKingSafe(board, fromRow, fromCol, toRow, toCol) == false)
            //{
            //    return false;
            //}

            return true;

        }

        return false;
    }


    private static bool IsPathClear(string[,] board, int fromRow, int fromCol, int toRow, int toCol)
    {

        if ((fromRow == toRow) || (fromCol == toCol))
        {

            return Rook.IsPathClear(board, fromRow, fromCol, toRow, toCol);

        }

        else
        {
            return Bishop.IsPathClear(board, fromRow, fromCol, toRow, toCol);
        }


        
    }

}
