using ChessLibrary;
using ChessLibrary.ChessPieces;
using Notifications.Wpf;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Chess.Desktop;

public partial class MainWindow : Window
{

    public static string[,] board = new string[8, 8];
    public Button? sourceButton;
    private char turn = 'W';
    private string? DefaultColor;
    public (int row, int col) from;
    private (int row, int col) to;
    private Button? destinationButton;
    Dictionary<Button, Brush> buttonBackgroundPairs = new();
    private bool isKingInCheck;

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
                destinationButton!.Content = DesktopUtilities.ButtonContent(0, 3);
                Utilities.MovePiece(board, from.row, from.col, to.row, to.col, "BQ");
            }
            else if (button.Tag.ToString() == "Bishop")
            {
                destinationButton!.Content = DesktopUtilities.ButtonContent(0, 2);
                Utilities.MovePiece(board, from.row, from.col, to.row, to.col, "BB");
            }
            else if (button.Tag.ToString() == "Knight")
            {
                destinationButton!.Content = DesktopUtilities.ButtonContent(0, 1);
                Utilities.MovePiece(board, from.row, from.col, to.row, to.col, "BN");
            }
            else if (button.Tag.ToString() == "Rook")
            {
                destinationButton!.Content = DesktopUtilities.ButtonContent(0, 0);
                Utilities.MovePiece(board, from.row, from.col, to.row, to.col, "BR");
            }


        }

        else if (board[from.row, from.col][0] == 'W')
        {
            if (button.Tag.ToString() == "Queen")
            {
                destinationButton!.Content = DesktopUtilities.ButtonContent(7, 3);
                Utilities.MovePiece(board, from.row, from.col, to.row, to.col, "WQ");
            }
            else if (button.Tag.ToString() == "Bishop")
            {
                destinationButton!.Content = DesktopUtilities.ButtonContent(7, 2);
                Utilities.MovePiece(board, from.row, from.col, to.row, to.col, "WB");
            }
            else if (button.Tag.ToString() == "Knight")
            {
                destinationButton!.Content = DesktopUtilities.ButtonContent(7, 1);
                Utilities.MovePiece(board, from.row, from.col, to.row, to.col, "WN");
            }
            else if (button.Tag.ToString() == "Rook")
            {
                destinationButton!.Content = DesktopUtilities.ButtonContent(7, 0);
                Utilities.MovePiece(board, from.row, from.col, to.row, to.col, "WR");
            }
        }

    }

    public void Btn_Click(object sender, RoutedEventArgs e)
    {
        Button button = (Button)sender;
        (int row, int col) = ((int, int))button.Tag;

        if (sourceButton == null)
        {
            if (OnFromBtnClick(button, row, col) == true)
            {
                HighlightPossibleMoves();
            }
        }
        else
        {

            OnToBtnClick(button, row, col);
        }




    }

    private void HighlightPossibleMoves()
    {
        var moves = Utilities.PossibleMoves(board, from.row, from.col);

        foreach (var move in moves)
        {
            if (DesktopUtilities.positionButtonPairs.TryGetValue((move.Row, move.Col), out Button? btn))
            {
                if (buttonBackgroundPairs.ContainsKey(btn) == false)
                {
                    buttonBackgroundPairs.Add(btn!, btn!.Background);
                    btn!.Background = Brushes.LightGray;
                }
            }

        }
    }

    private bool OnFromBtnClick(Button fromButton, int row, int col)
    {
        if (fromButton.Content == null)
        {
            sourceButton = null;
            return false;
        }
        else
        {
            DefaultColor = fromButton.Background.ToString();
            fromButton.Background = new SolidColorBrush(Color.FromRgb(246, 246, 105));
            sourceButton = fromButton;
            from = (row, col);
        }

        return true;
    }

    private void OnToBtnClick(Button toButton, int row, int col)
    {
        to = (row, col);
        destinationButton = toButton;
        if (IsSameColorPieceCaptured())
        {
            ResetButtonColorToDefault();
            sourceButton = null;
            destinationButton = null;
            return;
        }

       

        ResetButtonColorToDefault();

        bool isvalidMove = DesktopUtilities.PlayGame(board, from.row, from.col, to.row, to.col, turn);
        if (isvalidMove == false)
        {
            sourceButton = null;
            destinationButton = null;
            return;
        }

        else
        {

            if (Utilities.TryMove(board, from.row, from.col, to.row, to.col))
            {
                var notificationManager = new NotificationManager();

                if (isKingInCheck)
                {

                    notificationManager.Show(new NotificationContent
                    {
                        Title = "Invalid Move",
                        Message = "King is in check!",
                        Type = NotificationType.Error
                    });
                    sourceButton = null;
                    destinationButton = null;
                    return;

                }

                else
                {
                    notificationManager.Show(new NotificationContent
                    {
                        Title = "Invalid Move",
                        Message = "That move leads to king in check!",
                        Type = NotificationType.Error
                    });
                    sourceButton = null;
                    destinationButton = null;
                    return;
                }
            }

            MovePieceInBoard();

            isKingInCheck = IsOpponentkingInCheck(to.row, to.col);
            if (isKingInCheck)
            {
                DisplayKingUnderAttackInformation();
            }
            if (isKingInCheck && Utilities.IsThereAnyPossibleMoves(board, board[to.row, to.col][0]) == false)
            {
                ShowWinner("Shaheem");

            }
            else if (!isKingInCheck && Utilities.IsThereAnyPossibleMoves(board, board[to.row, to.col][0]) == false)
            {
                ShowStalemate();
            }
           
            turn = turn == 'B' ? 'W' : 'B';


            sourceButton!.Content = null;
            sourceButton = null;
            destinationButton = null;
        }
    }

    private void DisplayKingUnderAttackInformation()
    {

        if (board[to.row, to.col][0] == 'W')
        {
            var notificationManager = new NotificationManager();
            notificationManager.Show(new NotificationContent
            {
                Title = "Check",
                Message = "Black King under attack.",
                Type = NotificationType.Information
            });
        }
        else
        {
            var notificationManager = new NotificationManager();
            notificationManager.Show(new NotificationContent
            {
                Title = "Check",
                Message = "White King under attack.",
                Type = NotificationType.Information
            });
        }

    }

    private void ResetButtonColorToDefault()
    {
        sourceButton!.Background = (Brush?)new BrushConverter().ConvertFromString(DefaultColor!);

        foreach (var item in buttonBackgroundPairs)
        {
            var btn = item.Key;
            btn.Background = item.Value;
            buttonBackgroundPairs.Remove(btn);
        }


    }

    private bool IsSameColorPieceCaptured()
    {
        if (Utilities.IsSameColor(board[from.row, from.col], board[to.row, to.col]))
        {
            return true;
        }
        return false;
    }

    private void MovePieceInBoard()
    {

        if (IsPromotionMove())
        {

            return;
        }
        else
        {

            destinationButton!.Content = sourceButton!.Content;
            Utilities.MovePiece(board, from.row, from.col, to.row, to.col);

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

    private bool IsOpponentkingInCheck(int fromRow, int fromCol)
    {

        if (board[fromRow, fromCol][0] == 'W')
        {

            (int kingRow, int kingCol) = Utilities.FindIndexOfKing(board, 'B');

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j]?[0] == 'W')
                    {
                        if (Utilities.IsPieceToMoveValid(board, i, j, kingRow, kingCol))
                        {
                            return true;
                        }

                    }
                }
            }
        }

        else if (board[fromRow, fromCol][0] == 'B')
        {
            (int kingRow, int kingCol) = Utilities.FindIndexOfKing(board, 'W');

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j]?[0] == 'B')
                    {
                        if (Utilities.IsPieceToMoveValid(board, i, j, kingRow, kingCol))
                        {
                            return true;
                        }

                    }
                }
            }
        }

        return false;

    }

    private void ShowWinner(string winnerName)
    {
        // Display a message box announcing the winner
        MessageBox.Show($"{winnerName} won the game!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    private void ShowStalemate()
    {
        // Display a message box announcing stalemate
        MessageBox.Show("The game ended in a stalemate!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Warning);
    }




}

