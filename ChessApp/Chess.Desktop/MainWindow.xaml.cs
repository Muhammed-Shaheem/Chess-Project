using ChessLibrary;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Chess.Desktop;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public Button firstSelected;
    public (int Row, int Col) from;
    public static string?[,] board = new string[8, 8];
    private char turn='W';

    public MainWindow()
    {
        InitializeComponent();
        Utilities.InitializePieces(board);
        PrintChessBoard(board);


    }

    private void Btn_Click(object sender, RoutedEventArgs e)
    {
        Button button = sender as Button;
        (int row, int col) = ((int, int))button.Tag;

        if (firstSelected == null)
        {
            button.Background = Brushes.SlateGray;
            firstSelected = button;
            from = (row, col);
        }
        else
        {
            var (toRow, toCol) = (row, col);
       
            bool isvalid = DesktopUtilities.PlayGame(board, from.Row, from.Col, toRow, toCol,turn);
            if (isvalid == false)
            {
                firstSelected = null;
                PrintChessBoard(board);
                return;
            }
            firstSelected = null;
            PrintChessBoard(board);
            turn = turn == 'B' ? 'W' : 'B';

        }




    }


    public void PrintChessBoard(string[,] board)
    {

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Button button = new();
                button.Content = board[i, j];
                button.FontSize = 35;
                button.Click += Btn_Click;
                button.Tag = (i, j);
                if (i % 2 == 0)
                {

                    if (j % 2 == 0)
                    {
                        button.Background = Brushes.Beige;
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
                        button.Background = Brushes.Beige;

                    }
                }

                Grid.SetColumn(button, j);
                Grid.SetRow(button, i);


                ChessGrid.Children.Add(button);

            }
        }

    }
}

public static class test
{
    public static void testmethod()
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
    }
}