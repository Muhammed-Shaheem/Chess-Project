using ChessLibrary.ChessPieces;

namespace ChessLibrary;

public static class Utilities
{
    public static void MovePiece(string[,] board, int fromRow, int fromCol, int toRow, int toCol, string piece)
    {
        board[toRow, toCol] = piece;
        board[fromRow, fromCol] = null;
    }

    public static void InitializePieces(string?[,] board)
    {
        board[0, 0] = "BR"; // Rook
        board[0, 1] = "BN"; // Knight
        board[0, 2] = "BB"; // Bishop
        board[0, 3] = "BQ"; // Queen
        board[0, 4] = "BK"; // King
        board[0, 5] = "BB";
        board[0, 6] = "BN";
        board[0, 7] = "BR";

        board[7, 0] = "WR"; // Rook
        board[7, 1] = "WN"; // Knight
        board[7, 2] = "WB"; // Bishop
        board[7, 3] = "WQ"; // Queen
        board[7, 4] = "WK"; // King
        board[7, 5] = "WB";
        board[7, 6] = "WN";
        board[7, 7] = "WR";

        for (int i = 0; i < 8; i++)
        {
            board[1, i] = "BP";
            board[6, i] = "WP";
        }
    }

    public static bool IsValidMove(string[,] board, int fromRow, int fromCol, int toRow, int toCol, char pieceMoved)
    {
        bool isValidMove = false;
        switch (pieceMoved)
        {
            case 'P':
                isValidMove = Pawn.Move(board, fromRow, fromCol, toRow, toCol);
                break;
            case 'R':
                isValidMove = Rook.Move(board, fromRow, fromCol, toRow, toCol);
                break;
            case 'N':
                isValidMove = Knight.Move(board, fromRow, fromCol, toRow, toCol);
                break;
            case 'B':
                isValidMove = Bishop.Move(board, fromRow, fromCol, toRow, toCol);
                break;
            case 'Q':
                isValidMove = Queen.Move(board, fromRow, fromCol, toRow, toCol);
                break;
            case 'K':
                isValidMove = King.Move(board, fromRow, fromCol, toRow, toCol);
                break;

            default:
                break;
        }

        return isValidMove;
    }

    public static bool IsInsideBoard(int x)
    {
        return (x >= 1 && x <= 8);
    }

    public static bool HasPieceAt(string[,] board, int fromRow, int fromCol)
    {
        return board[fromRow, fromCol] == null;
    }

    public static bool IsSameColor(string fromPiece, string toPiece)
    {

       
            if (fromPiece[0] == toPiece[0])
            {
                return true;
            } 
        
        return false;
    }

    public static bool IsTargetOpponentKing(string opponentPiece,char oppponentColor)
    {
        if (opponentPiece == $"{oppponentColor}K")
        {
            return true;
        }
        return false;
    }



}
