using ChessLibrary;
using ChessLibrary.ChessPieces;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Chess.Desktop;

public partial class MainWindow : Window
{
    public Button? firstSelected;
    public (int Row, int Col) from;
    public static string[,] board = new string[8, 8];
    private char turn = 'W';
    private string DefaultColor;

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

    private void HighlightPossibleMoves(Button button)
    {
        if (button.Content.ToString() == "WP" || button.Content.ToString() == "BP")
        {
            var movesPossible = Pawn.PossibleMoves(board, from.Row, from.Col);
            foreach (var move in movesPossible)
            {

                foreach (var child in ChessGrid.Children)
                {
                    if (child is Button btn)
                    {
                        (int toRow, int toCol) = ((int, int))btn.Tag;

                        if (toRow == move.Row && toCol == move.Col)
                        {
                            btn.Background = Brushes.Aquamarine;
                            break;
                        }
                    }
                }
            }

        }
    }

    private void OnToBtnClick(int row, int col, Button button)
    {
        var (toRow, toCol) = (row, col);
        bool isvalidMove = DesktopUtilities.PlayGame(board, from.Row, from.Col, toRow, toCol, turn);
        if (isvalidMove == false)
        {
            firstSelected!.ClearValue(Button.BackgroundProperty);
            firstSelected = null;
            return;
        }

        else
        {
            firstSelected!.Background = (Brush?)new BrushConverter().ConvertFromString(DefaultColor);
            button.Content = firstSelected.Content;
            firstSelected.Content = null;
            firstSelected = null;
            turn = turn == 'B' ? 'W' : 'B';
        }
    }

    private void OnFromBtnClick(Button button, int row, int col)
    {
        DefaultColor = button.Background.ToString();
        button.Background = Brushes.IndianRed;
        firstSelected = button;
        from = (row, col);
    }
}

