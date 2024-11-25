public class TicTacToeModel
{
    public char[,] Board { get; private set; }
    public char CurrentPlayer { get; private set; } = 'X';

    private int winCondition = 5; // Đánh 5 ô liên tiếp để thắng

    public TicTacToeModel(int boardSize)
    {
        Board = new char[boardSize, boardSize];
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        for (int i = 0; i < Board.GetLength(0); i++)
        {
            for (int j = 0; j < Board.GetLength(1); j++)
            {
                Board[i, j] = '.'; // Ô trống là dấu '.'
            }
        }
    }

    public bool MakeMove(int row, int col)
    {
        if (row < 0 || col < 0 || row >= Board.GetLength(0) || col >= Board.GetLength(1) || Board[row, col] != '.')
        {
            return false; // Ô đã có người đánh
        }

        Board[row, col] = CurrentPlayer;
        CurrentPlayer = (CurrentPlayer == 'X') ? 'O' : 'X'; // Đổi lượt người chơi
        return true;
    }

    public bool CheckWin()
    {
        int size = Board.GetLength(0);

        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                if (Board[row, col] != '.')
                {
                    // Kiểm tra theo 4 hướng: ngang, dọc, chéo trái xuống, chéo phải xuống
                    if (CheckDirection(row, col, 1, 0) || // Ngang
                        CheckDirection(row, col, 0, 1) || // Dọc
                        CheckDirection(row, col, 1, 1) || // Chéo trái xuống
                        CheckDirection(row, col, 1, -1))  // Chéo phải xuống
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    private bool CheckDirection(int row, int col, int dRow, int dCol)
    {
        char player = Board[row, col];
        int count = 1; // Tính từ ô hiện tại

        for (int i = 1; i < winCondition; i++)
        {
            int newRow = row + dRow * i;
            int newCol = col + dCol * i;

            if (newRow < 0 || newCol < 0 || newRow >= Board.GetLength(0) || newCol >= Board.GetLength(1) || Board[newRow, newCol] != player)
            {
                break;
            }
            count++;
        }

        return count >= winCondition;
    }

    public bool IsDraw()
    {
        foreach (var spot in Board)
        {
            if (spot == '.')
            {
                return false;
            }
        }

        return true;
    }
}
