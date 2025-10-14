using ChessLibrary;
using ChessLibrary.ChessPieces;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Chess.Desktop;

public partial class MainWindow : Window
{

    public static string[,] board = new string[8, 8];
    public Button? firstSelected;
    private char turn = 'W';
    private string? DefaultColor;
    public (int Row, int Col) from;

    public MainWindow()
    {
        InitializeComponent();
        Utilities.InitializePieces(board);
        DesktopUtilities.PrintChessBoard(board, ChessGrid, this);


    }

    public void Btn_Click(object sender, RoutedEventArgs e)
    {
        Button button = (Button)sender;
        (int row, int col) = ((int, int))button.Tag;

        if (firstSelected == null)
        {
            OnFromBtnClick(button, row, col);
            //HighlightPossibleMoves(button);
        }
        else
        {

            OnToBtnClick(row, col, button);
        }




    }

    private void OnToBtnClick(int row, int col, Button button)
    {
        var (toRow, toCol) = (row, col);
        bool isvalidMove = DesktopUtilities.PlayGame(board, from.Row, from.Col, toRow, toCol, turn);
        if (isvalidMove == false)
        {
            firstSelected!.Background = (Brush?)new BrushConverter().ConvertFromString(DefaultColor!);
            firstSelected = null;
            return;
        }

        else
        {
            firstSelected!.Background = (Brush?)new BrushConverter().ConvertFromString(DefaultColor!);
            button.Content = firstSelected.Content;
            firstSelected.Content = null;
            firstSelected = null;
            turn = turn == 'B' ? 'W' : 'B';
        }
    }

    private void OnFromBtnClick(Button button, int row, int col)
    {
        if (button.Content == null)
        {
            firstSelected = null;
            return;
        }
        DefaultColor = button.Background.ToString();
        button.Background = new SolidColorBrush(Color.FromRgb(246, 246, 105));
        firstSelected = button;
        from = (row, col);
    }

}

