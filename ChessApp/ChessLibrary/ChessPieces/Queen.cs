
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

            Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "BQ");
            return true;



        }

        else if(board[fromRow, fromCol] == "WQ")
        {
            if (((fromRow == toRow || fromCol == toCol) || (Math.Abs(fromRow - toRow) == Math.Abs(fromCol - toCol))) == false)
            {
                return false;
            }


            if (IsPathClear(board, fromRow, fromCol, toRow, toCol) == false)
            {
                return false;
            }

            Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "BQ");
            return true;

        }

        return false;
    }



}
