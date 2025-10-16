using ChessLibrary;
using ChessLibrary.ChessPieces;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Chess.Desktop;

public partial class MainWindow : Window
{

    public static string[,] board = new string[8, 8];
    public Button? firstButton;
    private char turn = 'W';
    private string? DefaultColor;
    public (int row, int col) from;
    private (int row, int col) to;
    private Button? secondButton;

    public MainWindow()
    {
        InitializeComponent();
        Utilities.InitializePieces(board);
        DesktopUtilities.PrintChessBoard(board, ChessGrid, this);
        AddClickEventToPromoteBtn();


    }

    public void PromoteBtn_Click(object sender, RoutedEventArgs e)
    {
        Button button = (Button)sender;
        PromotionGrid.Visibility = Visibility.Collapsed;

        if (board[from.row, from.col][0] == 'B')
        {
            if (button.Tag.ToString() == "Queen")
            {
                secondButton!.Content = DesktopUtilities.ButtonContent(0, 3);
                Utilities.MovePiece(board, from.row, from.col, to.row, to.col, "BQ");
            }
            else if (button.Tag.ToString() == "Bishop")
            {
                secondButton!.Content = DesktopUtilities.ButtonContent(0, 2);
                Utilities.MovePiece(board, from.row, from.col, to.row, to.col, "BB");
            }
            else if (button.Tag.ToString() == "Knight")
            {
                secondButton!.Content = DesktopUtilities.ButtonContent(0, 1);
                Utilities.MovePiece(board, from.row, from.col, to.row, to.col, "BN");
            }
            else if (button.Tag.ToString() == "Rook")
            {
                secondButton!.Content = DesktopUtilities.ButtonContent(0, 0);
                Utilities.MovePiece(board, from.row, from.col, to.row, to.col, "BR");
            }


        }

        else if (board[from.row, from.col][0] == 'W')
        {
            if (button.Tag.ToString() == "Queen")
            {
                secondButton!.Content = DesktopUtilities.ButtonContent(7, 3);
                Utilities.MovePiece(board, from.row, from.col, to.row, to.col, "WQ");
            }
            else if (button.Tag.ToString() == "Bishop")
            {
                secondButton!.Content = DesktopUtilities.ButtonContent(7, 2);
                Utilities.MovePiece(board, from.row, from.col, to.row, to.col, "WB");
            }
            else if (button.Tag.ToString() == "Knight")
            {
                secondButton!.Content = DesktopUtilities.ButtonContent(7, 1);
                Utilities.MovePiece(board, from.row, from.col, to.row, to.col, "WN");
            }
            else if (button.Tag.ToString() == "Rook")
            {
                secondButton!.Content = DesktopUtilities.ButtonContent(7, 0);
                Utilities.MovePiece(board, from.row, from.col, to.row, to.col, "WR");
            }
        }

        firstButton!.Content = null;
        firstButton = null;
        secondButton = null;

    }

    public void Btn_Click(object sender, RoutedEventArgs e)
    {
        Button button = (Button)sender;
        (int row, int col) = ((int, int))button.Tag;

        if (firstButton == null)
        {
            OnFromBtnClick(button, row, col);
            //HighlightPossibleMoves(button);
        }
        else
        {

            OnToBtnClick(button, row, col);
        }




    }
    private void OnFromBtnClick(Button fromButton, int row, int col)
    {
        if (fromButton.Content == null)
        {
            firstButton = null;
            return;
        }
        else
        {
            DefaultColor = fromButton.Background.ToString();
            fromButton.Background = new SolidColorBrush(Color.FromRgb(246, 246, 105));
            firstButton = fromButton;
            from = (row, col);
        }
    }


    private void OnToBtnClick(Button toButton, int row, int col)
    {
        to = (row, col);
        secondButton = toButton;

        firstButton!.Background = (Brush?)new BrushConverter().ConvertFromString(DefaultColor!);

        bool isvalidMove = DesktopUtilities.PlayGame(board, from.row, from.col, to.row, to.col, turn);
        if (isvalidMove == false)
        {
            firstButton = null;
            return;
        }

        else
        {

            MovePieceInBoard();
            turn = turn == 'B' ? 'W' : 'B';

        }
    }

    private void MovePieceInBoard()
    {
        if (IsPromotionMove())
        {
            return;
        }
        else
        {
            secondButton!.Content = firstButton!.Content;
            Utilities.MovePiece(board, from.row, from.col, to.row, to.col);
            firstButton.Content = null;
            firstButton = null;
            secondButton = null;
        }
    }

    private bool IsPromotionMove()
    {
        if (board[from.row, from.col] == "BP" && (to.row == 7))
        {
            QueenPromoteBtn.Content = DesktopUtilities.ButtonContent(0, 3);
            BishopPromoteBtn.Content = DesktopUtilities.ButtonContent(0, 2);
            knightPromoteBtn.Content = DesktopUtilities.ButtonContent(0, 1);
            RookPromoteBtn.Content = DesktopUtilities.ButtonContent(0, 0);

            PromotionGrid.Visibility = Visibility.Visible;
            return true;
        }

        else if (board[from.row, from.col] == "WP" && (to.row == 0))
        {

            QueenPromoteBtn.Content = DesktopUtilities.ButtonContent(7, 3);
            BishopPromoteBtn.Content = DesktopUtilities.ButtonContent(7, 2);
            knightPromoteBtn.Content = DesktopUtilities.ButtonContent(7, 1);
            RookPromoteBtn.Content = DesktopUtilities.ButtonContent(7, 0);


            PromotionGrid.Visibility = Visibility.Visible;
            return true;
        }

        return false;

    }

    private void AddClickEventToPromoteBtn()
    {
        QueenPromoteBtn.Click += PromoteBtn_Click;
        BishopPromoteBtn.Click += PromoteBtn_Click;
        knightPromoteBtn.Click += PromoteBtn_Click;
        RookPromoteBtn.Click += PromoteBtn_Click;
    }
}

