using ChessLibrary;
using ChessLibrary.ChessPieces;
using Notifications.Wpf;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
    public static Dictionary<(int, int), Button> positionButtonPairs = new();


    public MainWindow()
    {
        InitializeComponent();
        Utilities.InitializePieces(board);
        PrintChessBoard();
        AddClickEventToPromoteBtn();

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

    private bool OnFromBtnClick(Button fromButton, int row, int col)
    {
        if (fromButton.Content == null)
        {
            sourceButton = null;
            return false;
        }
        else
        {
            HighlightFirstSelectedposition(fromButton);
            sourceButton = fromButton;
            from = (row, col);
        }

        return true;
    }

    private void HighlightFirstSelectedposition(Button fromButton)
    {
        DefaultColor = fromButton.Background.ToString();
        fromButton.Background = new SolidColorBrush(Color.FromRgb(246, 246, 105));
    }

    private void OnToBtnClick(Button toButton, int row, int col)
    {
        to = (row, col);
        destinationButton = toButton;
        if (Utilities.IsSameColor(board[from.row, from.col], board[to.row, to.col]))
        {
            ResetButtonColorsToDefault();
            MakeSourceAndDestinationButtonNull();
            return;
        }

        ResetButtonColorsToDefault();

        bool isvalidMove = PlayGame(board, from.row, from.col, to.row, to.col, turn);
        if (isvalidMove == false)
        {
            MakeSourceAndDestinationButtonNull();
            return;
        }

        else
        {

            if (Utilities.TryMove(board, from.row, from.col, to.row, to.col))
            {
                DisplayOnPossibleCheckMove();
                return;
            }

            MovePieceInBoard();

            isKingInCheck = Utilities.IsOpponentkingInCheck(board, to.row, to.col);
            if (isKingInCheck)
            {
                DisplayKingUnderAttackInformation();
            }

            DisplayIfCurrentPlayerWinOrDraw();

            turn = turn == 'B' ? 'W' : 'B';



        }
    }

    private void DisplayIfCurrentPlayerWinOrDraw()
    {
        if (isKingInCheck && Utilities.IsThereAnyPossibleMoves(board, board[to.row, to.col][0]) == false)
        {
            ShowWinner(board[to.row, to.col][0]);

        }
        else if (!isKingInCheck && Utilities.IsThereAnyPossibleMoves(board, board[to.row, to.col][0]) == false)
        {
            ShowStalemate();
        }
    }

    private void DisplayOnPossibleCheckMove()
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
            MakeSourceAndDestinationButtonNull();
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
            MakeSourceAndDestinationButtonNull();
            return;
        }
    }

    private void MakeSourceAndDestinationButtonNull()
    {
        sourceButton = null;
        destinationButton = null;
    }

    public void PromoteBtn_Click(object sender, RoutedEventArgs e)
    {
        Button button = (Button)sender;
        PromotionGrid.Visibility = Visibility.Collapsed;

        if (board[from.row, from.col][0] == 'B')
        {
            if (button.Tag.ToString() == "Queen")
            {
                destinationButton!.Content = ButtonContent(0, 3);
                Utilities.MovePiece(board, from.row, from.col, to.row, to.col, "BQ");
            }
            else if (button.Tag.ToString() == "Bishop")
            {
                destinationButton!.Content = ButtonContent(0, 2);
                Utilities.MovePiece(board, from.row, from.col, to.row, to.col, "BB");
            }
            else if (button.Tag.ToString() == "Knight")
            {
                destinationButton!.Content = ButtonContent(0, 1);
                Utilities.MovePiece(board, from.row, from.col, to.row, to.col, "BN");
            }
            else if (button.Tag.ToString() == "Rook")
            {
                destinationButton!.Content = ButtonContent(0, 0);
                Utilities.MovePiece(board, from.row, from.col, to.row, to.col, "BR");
            }


        }

        else if (board[from.row, from.col][0] == 'W')
        {
            if (button.Tag.ToString() == "Queen")
            {
                destinationButton!.Content = ButtonContent(7, 3);
                Utilities.MovePiece(board, from.row, from.col, to.row, to.col, "WQ");
            }
            else if (button.Tag.ToString() == "Bishop")
            {
                destinationButton!.Content = ButtonContent(7, 2);
                Utilities.MovePiece(board, from.row, from.col, to.row, to.col, "WB");
            }
            else if (button.Tag.ToString() == "Knight")
            {
                destinationButton!.Content = ButtonContent(7, 1);
                Utilities.MovePiece(board, from.row, from.col, to.row, to.col, "WN");
            }
            else if (button.Tag.ToString() == "Rook")
            {
                destinationButton!.Content = ButtonContent(7, 0);
                Utilities.MovePiece(board, from.row, from.col, to.row, to.col, "WR");
            }
        }
        sourceButton!.Content = null;
        MakeSourceAndDestinationButtonNull();
    }

    private void HighlightPossibleMoves()
    {
        var moves = Utilities.PossibleMoves(board, from.row, from.col);

        foreach (var move in moves)
        {
            if (positionButtonPairs.TryGetValue((move.Row, move.Col), out Button? btn))
            {
                if (buttonBackgroundPairs.ContainsKey(btn) == false)
                {
                    buttonBackgroundPairs.Add(btn!, btn!.Background);
                    btn.Background = new SolidColorBrush(Color.FromRgb(192, 192, 192));
                }
            }

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

    private void ResetButtonColorsToDefault()
    {
        sourceButton!.Background = (Brush?)new BrushConverter().ConvertFromString(DefaultColor!);

        foreach (var item in buttonBackgroundPairs)
        {
            var btn = item.Key;
            btn.Background = item.Value;
            buttonBackgroundPairs.Remove(btn);
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

            destinationButton!.Content = sourceButton!.Content;
            Utilities.MovePiece(board, from.row, from.col, to.row, to.col);
            sourceButton!.Content = null;
            MakeSourceAndDestinationButtonNull();
        }
    }

    private bool IsPromotionMove()
    {
        if (board[from.row, from.col] == "BP" && (to.row == 7))
        {
            QueenPromoteBtn.Content = ButtonContent(0, 3);
            BishopPromoteBtn.Content = ButtonContent(0, 2);
            knightPromoteBtn.Content = ButtonContent(0, 1);
            RookPromoteBtn.Content = ButtonContent(0, 0);

            PromotionGrid.Visibility = Visibility.Visible;
            return true;
        }

        else if (board[from.row, from.col] == "WP" && (to.row == 0))
        {

            QueenPromoteBtn.Content = ButtonContent(7, 3);
            BishopPromoteBtn.Content = ButtonContent(7, 2);
            knightPromoteBtn.Content = ButtonContent(7, 1);
            RookPromoteBtn.Content = ButtonContent(7, 0);


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

    private void ShowWinner(char color)
    {
        string winningPiece = color == 'W' ? "White" : "Black";
        // Display a message box announcing the winner
        MessageBox.Show($"{winningPiece} won the game!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    private void ShowStalemate()
    {
        // Display a message box announcing stalemate
        MessageBox.Show("The game ended in a stalemate!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Warning);
    }

    public void PrintChessBoard()
    {

        var green = new SolidColorBrush(Color.FromRgb(118, 150, 86));
        var yellow = new SolidColorBrush(Color.FromRgb(235, 236, 208));
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {

                Button button = new();
                button.Content = ButtonContent(i, j);
                button.FontSize = 35;
                button.Tag = (i, j);
                button.Click += Btn_Click;
                if (i % 2 == 0)
                {

                    if (j % 2 == 0)
                    {
                        button.Background = yellow;

                    }
                    else
                    {
                        button.Background = green;
                    }
                }
                else
                {
                    if (j % 2 == 0)
                    {
                        button.Background = green;
                    }
                    else
                    {
                        button.Background = yellow;

                    }
                }

                Grid.SetColumn(button, j);
                Grid.SetRow(button, i);


                ChessGrid.Children.Add(button);
                positionButtonPairs.Add((i, j), button);

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


        bool isValidMove = Utilities.IsPieceToMoveValid(board, fromRow, fromCol, toRow, toCol);
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

