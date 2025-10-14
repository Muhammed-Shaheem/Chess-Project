using ChessLibrary;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Chess.Desktop;

public static class DesktopUtilities
{
    public static void PrintChessBoard(string[,] board, Grid ChessGrid, MainWindow mainWindow)
    {


        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Button button = new();
                button.Content = board[i, j];
                button.FontSize = 35;
                button.Tag = (i, j);
                if (i % 2 == 0)
                {

                    if (j % 2 == 0)
                    {
                        button.Background = (Brush?)new BrushConverter().ConvertFromString("#ebecd0");

                    }
                    else
                    {
                        button.Background = (Brush?)new BrushConverter().ConvertFromString("#769656");
                    }
                }
                else
                {
                    if (j % 2 == 0)
                    {
                        button.Background = (Brush?)new BrushConverter().ConvertFromString("#769656");
                    }
                    else
                    {
                        button.Background = (Brush?)new BrushConverter().ConvertFromString("#ebecd0");

                    }
                }

                Grid.SetColumn(button, j);
                Grid.SetRow(button, i);


                ChessGrid.Children.Add(button);

            }
        }

    }


    public static bool PlayGame(string[,] board, int fromRow, int fromCol, int toRow, int toCol, char turn)
    {

        bool isValidInput = UserInputValidation(board, fromRow, fromCol, turn);
        if (isValidInput == false)
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
