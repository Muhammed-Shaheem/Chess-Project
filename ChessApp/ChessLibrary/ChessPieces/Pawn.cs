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
                if ((toRow == fromRow + 1 && toCol == fromCol - 1) == false)
                {
                    return false;
                }

                //striking move (checking if the striking move is possible on the right side) 
                else if ((toRow == fromRow + 1 && toCol == fromCol + 1) == false)
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

            if (toRow == 7)
            {
                char promotedTo = 'P';
                switch (promotedTo)
                {
                    case 'Q':
                        Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "BQ");
                        break;

                    case 'R':
                        Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "BR");
                        break;

                    case 'N':
                        Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "BN");
                        break;

                    case 'B':
                        Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "BB");
                        break;


                }

            }
                Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "BP");
                return true;
        }

        //if piece moved is White
        else if (board[fromRow, fromCol] == "WP")
        {
            if (board[toRow, toCol] != null)
            {
                //striking move (checking if the striking move is possible on left side)
                if ((toRow == fromRow - 1 && toCol == fromCol - 1) == false)
                {
                    return false;
                }

                //striking move (checking if the striking move is possible on right side)
                else if ((toRow == fromRow - 1 && toCol == fromCol + 1) == false)
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


                if ((toRow == fromRow - 2 ))
                {
                    if (board[fromRow - 1, toCol] != null)
                    {
                        return false;
                    }

                }

            }

            if (toRow == 0)
            {
                char promotedTo = 'P';
                switch (promotedTo)
                {
                    case 'Q':
                        Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "WQ");
                        break;

                    case 'R':
                        Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "WR");
                        break;

                    case 'N':
                        Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "WN");
                        break;

                    case 'B':
                        Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "WB");
                        break;


                }
            }

            Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "WP");
            return true;
        }

        return false;


    }
}
