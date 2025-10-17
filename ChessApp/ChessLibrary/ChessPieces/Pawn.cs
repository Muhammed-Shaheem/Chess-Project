namespace ChessLibrary.ChessPieces;

public static class Pawn
{
    public static bool Move(string[,] board, int fromRow, int fromCol, int toRow, int toCol)
    {
        if (board[toRow, toCol] != null && Utilities.IsSameColor(board[fromRow, fromCol], board[toRow, toCol]))
        {
            return false;
        }


        if (board[fromRow, fromCol] == "BP")
        {
            if (board[toRow, toCol] != null)
            {
                //striking move (checking if the striking move is possible on the left side) 
                if (((toRow == fromRow + 1 && toCol == fromCol - 1) || (toRow == fromRow + 1 && toCol == fromCol + 1)) == false)
                {
                    return false;
                }

            }

            //straight move (checking if a piece is placed infront)
            else if (board[toRow, toCol] == null)
            {
                if (((toRow == fromRow + 1 && toCol == fromCol) || (toRow == fromRow + 2 && toCol == fromCol && fromRow == 1)) == false)
                {
                    return false;
                }

                if ((toRow == fromRow + 2))
                {
                    if (board[fromRow + 1, toCol] != null)
                    {
                        return false;
                    }

                }

                //if (Utilities.IsKingSafe(board, fromRow, fromCol, toRow, toCol) == false)
                //{
                //    return false;
                //}
            }


            return true;

        }

        //if piece moved is White
        else if (board[fromRow, fromCol] == "WP")
        {
            if (board[toRow, toCol] != null)
            {
                //striking move (checking if the striking move is possible on left side)
                if (((toRow == fromRow - 1 && toCol == fromCol - 1) || (toRow == fromRow - 1 && toCol == fromCol + 1)) == false)
                {
                    return false;
                }

            }

            else if (board[toRow, toCol] == null)
            {
                if (((toRow == fromRow - 1 && toCol == fromCol) || (toRow == fromRow - 2 && toCol == fromCol && fromRow == 6)) == false)
                {
                    return false;
                }


                if ((toRow == fromRow - 2))
                {
                    if (board[fromRow - 1, toCol] != null)
                    {
                        return false;
                    }

                }

                //if (Utilities.IsKingSafe(board, fromRow, fromCol, toRow, toCol) == false)
                //{
                //    return false;
                //}



            }


            return true;

        }

        return false;


    }

  

    public static bool IsMovePossible(string[,] board, int fromRow, int fromCol, int toRow, int toCol)
    {
        if (board[toRow, toCol] != null && Utilities.IsSameColor(board[fromRow, fromCol], board[toRow, toCol]))
        {
            return false;
        }


        if (board[fromRow, fromCol] == "BP")
        {
            if (board[toRow, toCol] != null)
            {
                //striking move (checking if the striking move is possible on the left side) 
                if (((toRow == fromRow + 1 && toCol == fromCol - 1) || (toRow == fromRow + 1 && toCol == fromCol + 1)) == false)
                {
                    return false;
                }

            }

            //straight move (checking if a piece is placed infront)
            else if (board[toRow, toCol] == null)
            {
                if (((toRow == fromRow + 1 && toCol == fromCol) || (toRow == fromRow + 2 && toCol == fromCol && fromRow == 1)) == false)
                {
                    return false;
                }

                if ((toRow == fromRow + 2))
                {
                    if (board[fromRow + 1, toCol] != null)
                    {
                        return false;
                    }

                }
            }


            return true;
        }

        //if piece moved is White
        else if (board[fromRow, fromCol] == "WP")
        {
            if (board[toRow, toCol] != null)
            {
                //striking move (checking if the striking move is possible on left side)
                if (((toRow == fromRow - 1 && toCol == fromCol - 1) || (toRow == fromRow - 1 && toCol == fromCol + 1)) == false)
                {
                    return false;
                }

            }

            else if (board[toRow, toCol] == null)
            {
                if (((toRow == fromRow - 1 && toCol == fromCol) || (toRow == fromRow - 2 && toCol == fromCol && fromRow == 6)) == false)
                {
                    return false;
                }


                if ((toRow == fromRow - 2))
                {
                    if (board[fromRow - 1, toCol] != null)
                    {
                        return false;
                    }

                }

            }



            return true;
        }

        return false;


    }

  
}
