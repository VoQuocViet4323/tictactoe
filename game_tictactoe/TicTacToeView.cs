using System;

public class TicTacToeView
{
    public void DisplayBoard(char[,] board, int cursorRow, int cursorCol)
    {
        Console.Clear();
        int size = board.GetLength(0);

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.SetCursorPosition(j * 2, i); // Dãn khoảng cách để dễ nhìn
                
                char displayChar = board[i, j] == ' ' ? '.' : board[i, j];

                if (i == cursorRow && j == cursorCol)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.Write(displayChar);
                Console.ResetColor();
            }
        }
    }

    public void DisplayMessage(string message)
    {
        Console.SetCursorPosition(0, 20); // Đặt thông báo phía dưới bảng
        Console.WriteLine(message);
    }

    public ConsoleKey GetInput()
    {
        return Console.ReadKey(true).Key;
    }
}
