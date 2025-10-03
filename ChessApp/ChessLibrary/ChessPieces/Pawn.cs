namespace ChessLibrary.ChessPieces;

public static class Pawn
{
    public static bool Move(string[,] board, int fromRow, int fromCol, int toRow, int toCol)
    {

        if (board[fromRow, fromCol] == "BP")
        {
          
            //striking move (checking if the striking move is possible on the left side) 
            if ((toRow == fromRow + 1 && toCol == fromCol - 1) && board[toRow, toCol] != null)
            {
                // if the piece in the target is black or king then return false
                char? firstChar = board[fromRow + 1, fromCol - 1]![0];
                if (firstChar == 'B')
                {
                    return false;
                }
                else if (board[fromRow + 1, fromCol - 1] == "Wk")
                {
                    return false;
                }

                else
                {
                    Utilities.MovePiece(board,fromRow, fromCol, toRow, toCol, "BP");
                    return true;
                }
            }

            //striking move (checking if the striking move is possible on the right side) 
            else if ((toRow == fromRow + 1 && toCol == fromCol + 1) && board[toRow, toCol] != null)
            {
                char? firstChar = board[fromRow + 1, fromCol + 1]![0];

                if (board[fromRow + 1, fromCol + 1] == "Wk")
                {
                    return false;
                }
                else if (firstChar == 'B')
                {
                    return false;
                }

                else
                {
                    Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "BP");
                    return true;
                }
            }

            //straight move (checking if a piece is placed infront)
            else if (board[toRow, toCol] == null)
            {
                if (fromRow == 1)
                {
                    if ((toRow == fromRow + 2 && toCol == fromCol))
                    {
                        if (board[fromRow + 1, toCol] != null)
                        {
                            return false;
                        }

                        Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "BP");
                        return true;
                    }
                }

                if ((toRow == fromRow + 1 && toCol == fromCol))
                {

                    Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "BP");
                    return true;
                }
            }
        }

        //if piece moved is White
        else if (board[fromRow, fromCol] == "WP")
        {
            //striking move (checking if the striking move is possible on left side)
            if ((toRow == fromRow - 1 && toCol == fromCol - 1) && (board[fromRow - 1, fromCol - 1] != null))
            {
                // if the piece in the target is black or king then return false
                char? firstChar = board[fromRow + 1, fromCol - 1]![0];
                if (firstChar == 'W')
                {
                    return false;
                }
                else if (board[fromRow + 1, fromCol - 1] == "Wk")
                {
                    return false;
                }

                else
                {
                    Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "WP");
                    return true;
                }
            }

            //striking move (checking if the striking move is possible on right side)
            else if ((toRow == fromRow - 1 && toCol == fromCol + 1) && (board[fromRow - 1, fromCol + 1] != null))
            {
                char? firstChar = board[fromRow + 1, fromCol - 1]![0];
                if (firstChar == 'W')
                {
                    return false;
                }
                else if (board[fromRow + 1, fromCol - 1] == "Bk")
                {
                    return false;
                }

                else
                {
                    Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "WP");
                    return true;
                }
            }

            else if (board[toRow, toCol] == null)
            {

                if (fromRow == 6)
                {
                    if ((toRow == fromRow - 2 && toCol == fromCol))
                    {
                        if (board[fromRow - 1, toCol] != null)
                        {
                            return false;
                        }

                        else
                        {
                            Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "WP");
                            return true;
                        }
                    }
                }


                if ((toRow == fromRow - 1 && toCol == fromCol))
                {
                    Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "WP");
                    return true;
                }
            }
        }

        return false;

    }
}
