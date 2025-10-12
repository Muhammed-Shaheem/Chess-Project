namespace ChessLibrary.ChessPieces;

public static class Rook
{
    public static bool Move(string[,] board, int fromRow, int fromCol, int toRow, int toCol)
    {
        //Prevent capturing own pieces
        if (board[toRow, toCol] != null && Utilities.IsSameColor(board[fromRow, fromCol], board[toRow, toCol]))
        {
            return false;
        }



        if (board[fromRow, fromCol] == "BR")
        {

            if ((fromRow == toRow || fromCol == toCol) == false)
            {
                return false;
            }

            if (IsPathClear(board, fromRow, fromCol, toRow, toCol) == false)
            {
                return false;
            }

            Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "BR");
            return true;
        }

        else if (board[fromRow, fromCol] == "WR")
        {
            if ((fromRow == toRow || fromCol == toCol) == false)
            {
                return false;
            }

            if (IsPathClear(board, fromRow, fromCol, toRow, toCol) == false)
            {
                return false;
            }

            Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "WR");
            return true;
        }

        return false;
    }

    public static bool IsPathClear(string[,] board, int fromRow, int fromCol, int toRow, int toCol)
    {
        if (fromRow != toRow)
        {
            int length = Math.Abs(fromRow - toRow);
            if (fromRow < toRow)
            {
                for (int i = 1; i < length; i++)
                {
                    if (board[fromRow + i, toCol] != null)
                    {
                        return false;
                    }
                }
            }
            else if (fromRow > toRow)
            {
                for (int i = 1; i < length; i++)
                {
                    if (board[fromRow - i, toCol] != null)
                    {
                        return false;
                    }
                }
            }
        }
        else if (fromCol != toCol)
        {
            int length = Math.Abs(fromRow - toRow);
            if (fromCol < toCol)
            {
                for (int i = 1; i < length - 1; i++)
                {
                    if (board[fromRow, toCol + i] != null)
                    {
                        return false;
                    }
                }
            }
            else if (fromRow > toRow)
            {
                for (int i = 1; i < length - 1; i++)
                {
                    if (board[fromRow, toCol - i] != null)
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }
}

