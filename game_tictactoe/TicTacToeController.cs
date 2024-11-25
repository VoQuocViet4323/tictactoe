public class TicTacToeController
{
    private TicTacToeModel _model;
    private TicTacToeView _view;

    private int cursorRow = 0;
    private int cursorCol = 0;

    public TicTacToeController(TicTacToeModel model, TicTacToeView view)
    {
        _model = model;
        _view = view;
    }

    public bool Run()
    {
        while (true)
        {
            _view.DisplayBoard(_model.Board, cursorRow, cursorCol);
            _view.DisplayMessage("Press ESC to stop or Enter to play.");

            if (_model.CheckWin())
            {
                _view.DisplayMessage($"Player {(_model.CurrentPlayer == 'X' ? 'O' : 'X')} wins!");
                break;
            }

            if (_model.IsDraw())
            {
                _view.DisplayMessage("It's a draw!");
                break;
            }

            var key = _view.GetInput();

            if (key == ConsoleKey.Escape) // Dừng và quay lại menu
            {
                return false;
            }

            HandleInput(key);
        }

        Console.SetCursorPosition(0, 22);
        Console.WriteLine("Press any key to return to menu...");
        Console.ReadKey();
        return true;
    }

    private void HandleInput(ConsoleKey key)
    {
        int size = _model.Board.GetLength(0);

        switch (key)
        {
            case ConsoleKey.UpArrow:
                cursorRow = cursorRow == 0 ? size - 1 : cursorRow - 1;
                break;
            case ConsoleKey.DownArrow:
                cursorRow = cursorRow == size - 1 ? 0 : cursorRow + 1;
                break;
            case ConsoleKey.LeftArrow:
                cursorCol = cursorCol == 0 ? size - 1 : cursorCol - 1;
                break;
            case ConsoleKey.RightArrow:
                cursorCol = cursorCol == size - 1 ? 0 : cursorCol + 1;
                break;
            case ConsoleKey.Enter:
                if (!_model.MakeMove(cursorRow, cursorCol))
                {
                    _view.DisplayMessage("Spot already taken!");
                    System.Threading.Thread.Sleep(1000);
                }
                break;
        }
    }
}
