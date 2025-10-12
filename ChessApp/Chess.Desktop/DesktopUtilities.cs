using ChessLibrary;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Chess.Desktop;

public class DesktopUtilities
{
    public static bool PlayGame(string[,] board, int fromRow, int fromCol, int toRow, int toCol,char turn)
    {

        bool isValid = UserInputValidation(board, fromRow, fromCol, turn);
        if (isValid == false)
        {
            return false;
        }
        bool isValidMove = Utilities.PieceToMove(board, fromRow, fromCol, toRow, toCol);
        if (isValidMove == false)
        {
            MessageBox.Show("Invalid Move.");
            return false;
        }


        return true;
    }


    public static bool UserInputValidation(string[,] board, int fromRow, int fromCol, char turn)
    { 
        if (Utilities.HasPieceAt(board, fromRow, fromCol))
        {
            //Ensure piece present
            MessageBox.Show("No piece selected to move.");
            //goto FromRow;
            return false;

        }

        char wOrB = board[fromRow, fromCol][0];
        if (wOrB != turn) // Ensure player moves their own piece
        {

            if (turn == 'W')
            {
                MessageBox.Show($"Cannot move black piece.Its white's turn.");
                //goto FromRow;
                return false;
            }
            else
            {
                MessageBox.Show($"Cannot move white piece.Its black's turn.");
                //goto FromRow;
                return false;
            }
        }
        return true;
    }


}
