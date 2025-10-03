namespace ChessLibrary.ChessPieces;

public static class Rook
{
    public static bool Move(string[,] board, int fromRow, int fromCol, int toRow, int toCol)
    {
        if (board[fromRow, fromCol] == "BR")
        {
            if (fromRow == toRow || fromCol == toCol)
            {
                // checking if any piece placed in between from and to square
                if (fromRow != toRow)
                {
                    for (int i = fromRow + 1; i < toRow; i++)
                    {
                        if (board[i, toCol]?[0] == 'B' || board[i, toCol]?[0] == 'W')
                        {
                            return false;
                        }
                    }
                }
                else if (fromCol != toCol)
                {
                    for (int i = fromCol + 1; i < toCol; i++)
                    {
                        if (board[toRow, i]?[0] == 'B' || board[toRow, i]?[0] == 'W')
                        {
                            return false;
                        }
                    }
                }

                // strike opponent piece else move piece 
                if (board[toRow, toCol] != null)
                {
                    // if the piece in the target is black or opponet king then return false
                    char? firstChar = board[toRow, toCol]![0];
                    if (firstChar == 'B')
                    {
                        return false;
                    }
                    else if (board[toRow, toCol] == "Wk")
                    {
                        return false;
                    }
                    else
                    {
                        Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "BR");
                        return true;
                    }
                }
                else
                {
                    Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "BR");
                    return true;

                }
            }

        }
        if (board[fromRow, fromCol] == "WR")
        {
            // checking if any piece placed in between from and to square
            if (fromRow != toRow)
            {
                for (int i = fromRow + 1; i < toRow; i++)
                {
                    if (board[i, toCol]?[0] == 'B' || board[i, toCol]?[0] == 'W')
                    {
                        return false;
                    }
                }
            }
            else if (fromCol != toCol)
            {
                for (int i = fromCol + 1; i < toCol; i++)
                {
                    if (board[toRow, i]?[0] == 'B' || board[toRow, i]?[0] == 'W')
                    {
                        return false;
                    }
                }
            }

            // checking if any piece placed in between from and to square
            if (fromRow == toRow || fromCol == toCol)
            {
                if (fromRow != toRow)
                {
                    for (int i = fromRow + 1; i < toRow; i++)
                    {
                        if (board[i, toCol]?[0] == 'B' || board[i, toCol]?[0] == 'W')
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    for (int i = fromCol + 1; i < toCol; i++)
                    {
                        if (board[toRow, i]?[0] == 'B' || board[toRow, i]?[0] == 'W')
                        {
                            return false;
                        }
                    }
                }

                // strike opponent piece else move piece 
                if (board[toRow, toCol] != null)
                {
                    // if the piece in the target is black or opponet king then return false
                    char? firstChar = board[toRow, toCol]![0];
                    if (firstChar == 'W')
                    {
                        return false;
                    }
                    else if (board[toRow, toCol] == "Bk")
                    {
                        return false;
                    }
                    else
                    {
                        Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "WR");
                        return true;
                    }
                }
                else
                {
                    Utilities.MovePiece(board, fromRow, fromCol, toRow, toCol, "WR");
                    return true;

                }
            }

        }
        return false;
    }
}
