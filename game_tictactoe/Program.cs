class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            int boardSize = DisplayMenu();

            TicTacToeModel model = new TicTacToeModel(boardSize);
            TicTacToeView view = new TicTacToeView();
            TicTacToeController controller = new TicTacToeController(model, view);

            bool continuePlaying = controller.Run();

            if (!continuePlaying)
            {
                Console.Clear();
                Console.WriteLine("Bạn đã dừng trò chơi. Quay lại menu...");
                System.Threading.Thread.Sleep(2000);
            }
        }
    }

    static int DisplayMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Chọn kích thước bảng chơi:");
            Console.WriteLine("1. 3x3");
            Console.WriteLine("2. 10x10");
            Console.WriteLine("3. 20x20");
            Console.Write("Nhập lựa chọn (1, 2 hoặc 3): ");

            var input = Console.ReadKey(true).Key;
            if (input == ConsoleKey.D1 || input == ConsoleKey.NumPad1)
            {
                return 3; // Bảng 3x3
            }
            else if (input == ConsoleKey.D2 || input == ConsoleKey.NumPad2)
            {
                return 10; // Bảng 10x10
            }
            else if (input == ConsoleKey.D3 || input == ConsoleKey.NumPad3)
            {
                return 20; // Bảng 20x20
            }
            else
            {
                Console.WriteLine("Lựa chọn không hợp lệ. Nhấn phím bất kỳ để thử lại.");
                Console.ReadKey();
            }
        }
    }
}
