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

        if (board[fromRow, fromCol] == "WR")
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

    private static bool IsPathClear(string[,] board, int fromRow, int fromCol, int toRow, int toCol)
    {
        if (fromRow != toRow)
        {
            int length = Math.Abs(fromRow - toRow);
            if (fromRow < toRow)
            {
                for (int i = 1; i < length ; i++)
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


// checking if any piece placed in between from and to square
//if (fromRow != toRow)
//{
//    for (int i = fromRow + 1; i < toRow; i++)
//    {
//        if (board[i, toCol]?[0] == 'B' || board[i, toCol]?[0] == 'W')
//        {
//            return false;
//        }
//    }
//}
//else if (fromCol != toCol)
//{
//    for (int i = fromCol + 1; i < toCol; i++)
//    {
//        if (board[toRow, i]?[0] == 'B' || board[toRow, i]?[0] == 'W')
//        {
//            return false;
//        }
//    }
//}

//// checking if any piece placed in between from and to square
//if (fromRow != toRow)
//{
//    for (int i = fromRow + 1; i < toRow; i++)
//    {
//        if (board[i, toCol]?[0] == 'B' || board[i, toCol]?[0] == 'W')
//        {
//            return false;
//        }
//    }
//}
//else if (fromCol != toCol)
//{
//    for (int i = fromCol + 1; i < toCol; i++)
//    {
//        if (board[toRow, i]?[0] == 'B' || board[toRow, i]?[0] == 'W')
//        {
//            return false;
//        }
//    }
//}