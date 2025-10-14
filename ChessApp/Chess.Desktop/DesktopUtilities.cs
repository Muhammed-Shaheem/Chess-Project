using ChessLibrary;
using Notifications.Wpf;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
                
                button.Content = ButtonContent(i,j);
                button.FontSize = 35;
                button.Tag = (i, j);
                button.Click += mainWindow.Btn_Click;
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



    public static Image? ButtonContent(int row, int col)
    {
        Image img = new();
        img.Height = 50;
        img.Width = 50;
        if (row == 1)
        {
            img.Source = new BitmapImage(new Uri("C:\\Users\\shahe\\source\\repos\\Chess-Project\\ChessApp\\Chess.Desktop\\Images\\BP.png"));
            
        }
        else if ((row == 0 && col == 0) || (row == 0 && col == 7))
        {
            img.Source = new BitmapImage(new Uri("C:\\Users\\shahe\\source\\repos\\Chess-Project\\ChessApp\\Chess.Desktop\\Images\\BR.png"));
        }

        else if ((row == 0 && col == 1) || (row == 0 && col == 6))
        {
            img.Source = new BitmapImage(new Uri("C:\\Users\\shahe\\source\\repos\\Chess-Project\\ChessApp\\Chess.Desktop\\Images\\BN.png"));
        }
        
        else if ((row == 0 && col == 2) || (row == 0 && col == 5))
        {
            img.Source = new BitmapImage(new Uri("C:\\Users\\shahe\\source\\repos\\Chess-Project\\ChessApp\\Chess.Desktop\\Images\\BB.png"));
        }
        
        else if ((row == 0 && col == 3))
        {
            img.Source = new BitmapImage(new Uri("C:\\Users\\shahe\\source\\repos\\Chess-Project\\ChessApp\\Chess.Desktop\\Images\\BQ.png"));
        }
        
        else if ((row == 0 && col == 4))
        {
            img.Source = new BitmapImage(new Uri("C:\\Users\\shahe\\source\\repos\\Chess-Project\\ChessApp\\Chess.Desktop\\Images\\BK.png"));
        }
        
        else if ((row == 7 && col == 0) || (row == 7 && col == 7))
        {
            img.Source = new BitmapImage(new Uri("C:\\Users\\shahe\\source\\repos\\Chess-Project\\ChessApp\\Chess.Desktop\\Images\\WR.png"));
        }
        
        else if ((row == 7 && col == 1) || (row == 7 && col == 6))
        {
            img.Source = new BitmapImage(new Uri("C:\\Users\\shahe\\source\\repos\\Chess-Project\\ChessApp\\Chess.Desktop\\Images\\WN.png"));
        }
        
        else if ((row == 7 && col == 2) || (row == 7 && col == 5))
        {
            img.Source = new BitmapImage(new Uri("C:\\Users\\shahe\\source\\repos\\Chess-Project\\ChessApp\\Chess.Desktop\\Images\\WB.png"));
        }
        
        else if ((row == 7 && col == 3))
        {
            img.Source = new BitmapImage(new Uri("C:\\Users\\shahe\\source\\repos\\Chess-Project\\ChessApp\\Chess.Desktop\\Images\\WQ.png"));
        }
        
        else if ((row == 7 && col == 4))
        {
            img.Source = new BitmapImage(new Uri("C:\\Users\\shahe\\source\\repos\\Chess-Project\\ChessApp\\Chess.Desktop\\Images\\WK.png"));
        }
        
        else if (row == 6)
        {
            img.Source = new BitmapImage(new Uri("C:\\Users\\shahe\\source\\repos\\Chess-Project\\ChessApp\\Chess.Desktop\\Images\\WP.png"));
        }
        else
        {
            img = null;
        }

        return img;
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
            var notificationManager = new NotificationManager();
            notificationManager.Show(new NotificationContent
            {
                Title = "Invalid Move",
                Message = "That move is not allowed!",
                Type = NotificationType.Error
            });
            return false;
        }


        return true;
    }

    public static bool UserInputValidation(string[,] board, int fromRow, int fromCol, char turn)
    {
        if (Utilities.HasPieceAt(board, fromRow, fromCol))
        {
            //Ensure piece present
            var notificationManager = new NotificationManager();
            notificationManager.Show(new NotificationContent
            {
                Title = "Invalid Move",
                Message = "No piece selected to move.",
                Type = NotificationType.Error
            });
            return false;

        }

        char wOrB = board[fromRow, fromCol][0];
        if (wOrB != turn) // Ensure player moves their own piece
        {

            if (turn == 'W')
            {
                var notificationManager = new NotificationManager();
                notificationManager.Show(new NotificationContent
                {
                    Title = "Invalid Move",
                    Message = "Cannot move black piece.Its white's turn.",
                    Type = NotificationType.Error
                });
                return false;
            }
            else
            {
                var notificationManager = new NotificationManager();
                notificationManager.Show(new NotificationContent
                {
                    Title = "Invalid Move",
                    Message = "Cannot move white piece.Its black's turn.",
                    Type = NotificationType.Error
                });
                return false;
            }
        }
        return true;
    }

}
