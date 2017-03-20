namespace Mines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Contracts;
    using Models;

    public class StartUp
    {
        public static void Main()
        {
            const int MaxEmptyFields = 35;

            string command = string.Empty;
            char[,] board = CreateGameBoard();
            char[,] mines = FillBoardWithMines();
            int moves = 0;
            bool isMineDetonated = false;
            List<IPlayer> topPlayers = new List<IPlayer>(6);
            int row = 0;
            int col = 0;
            bool startGame = true;
            bool winGame = false;

            do
            {
                if (startGame)
                {
                    Console.WriteLine("Welcome to \"Mines\" game. Try to avoid openning a mine field.\nCommands: 'top' - display best scores, 'restart' - start new game, 'exit' - quit current game");
                    ShowGameBoard(board);
                    startGame = false;
                }

                Console.Write("Enter row and column separated by single space: ");
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out col) &&
                        row <= board.GetLength(0) && col <= board.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        ShowTopScores(topPlayers);
                        break;
                    case "restart":
                        board = CreateGameBoard();
                        mines = FillBoardWithMines();
                        ShowGameBoard(board);
                        isMineDetonated = false;
                        startGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, bye, bye!");
                        break;
                    case "turn":
                        if (mines[row, col] != '*')
                        {
                            if (mines[row, col] == '-')
                            {
                                NextMove(board, mines, row, col);
                                moves++;
                            }

                            if (MaxEmptyFields == moves)
                            {
                                winGame = true;
                            }
                            else
                            {
                                ShowGameBoard(board);
                            }
                        }
                        else
                        {
                            isMineDetonated = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! Invalid command!\n");
                        break;
                }

                if (isMineDetonated)
                {
                    ShowGameBoard(mines);
                    Console.Write("\nYou stepped on a mine! Final score: {0}.\nEnter your nickname: ", moves);
                    string nickname = Console.ReadLine();
                    var player = new Player(nickname, moves);

                    if (topPlayers.Count < 5)
                    {
                        topPlayers.Add(player);
                    }
                    else
                    {
                        for (int i = 0; i < topPlayers.Count; i++)
                        {
                            if (topPlayers[i].Result < player.Result)
                            {
                                topPlayers.Insert(i, player);
                                topPlayers.RemoveAt(topPlayers.Count - 1);
                                break;
                            }
                        }
                    }

                    topPlayers.Sort((IPlayer r1, IPlayer r2) => r2.Name.CompareTo(r1.Name));
                    topPlayers.Sort((IPlayer r1, IPlayer r2) => r2.Result.CompareTo(r1.Result));
                    ShowTopScores(topPlayers);

                    board = CreateGameBoard();
                    mines = FillBoardWithMines();
                    moves = 0;
                    isMineDetonated = false;
                    startGame = true;
                }

                if (winGame)
                {
                    Console.WriteLine("\nCongratulations! You won the game!.");
                    ShowGameBoard(mines);
                    Console.WriteLine("Please enter your name: ");
                    string name = Console.ReadLine();
                    var player = new Player(name, moves);
                    topPlayers.Add(player);
                    ShowTopScores(topPlayers);

                    board = CreateGameBoard();
                    mines = FillBoardWithMines();
                    moves = 0;
                    winGame = false;
                    startGame = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria!");
            Console.WriteLine("Let\'s goo!");
            Console.Read();
        }

        private static char[,] CreateGameBoard()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];

            for (int boardRow = 0; boardRow < boardRows; boardRow++)
            {
                for (int boardCol = 0; boardCol < boardColumns; boardCol++)
                {
                    board[boardRow, boardCol] = '?';
                }
            }

            return board;
        }

        private static char[,] FillBoardWithMines()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];

            for (int boardRow = 0; boardRow < boardRows; boardRow++)
            {
                for (int boardCol = 0; boardCol < boardColumns; boardCol++)
                {
                    board[boardRow, boardCol] = '-';
                }
            }

            List<int> minesList = new List<int>();
            Random randomGenerator = new Random();

            while (minesList.Count < 15)
            {
                int mineIndex = randomGenerator.Next(50);

                if (!minesList.Contains(mineIndex))
                {
                    minesList.Add(mineIndex);
                }
            }

            foreach (int index in minesList)
            {
                int row = index / boardColumns;
                int col = index % boardColumns;

                if (col == 0 && index != 0)
                {
                    row--;
                    col = boardColumns;
                }
                else
                {
                    col++;
                }

                board[row, col - 1] = '*';
            }

            return board;
        }

        private static void ShowGameBoard(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int row = 0; row < rows; row++)
            {
                Console.Write("{0} | ", row);

                for (int col = 0; col < cols; col++)
                {
                    Console.Write(string.Format("{0} ", board[row, col]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static void ShowTopScores(List<IPlayer> topPlayers)
        {
            Console.WriteLine("\nBest scores:");

            if (topPlayers.Count > 0)
            {
                for (int i = 0; i < topPlayers.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} scores", i + 1, topPlayers[i].Name, topPlayers[i].Result);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("There is no data!\n");
            }
        }

        private static void NextMove(char[,] board, char[,] mines, int row, int col)
        {
            char foundMines = CountMinesAround(mines, row, col);
            mines[row, col] = foundMines;
            board[row, col] = foundMines;
        }

        private static char CountMinesAround(char[,] mines, int currentRow, int currentCol)
        {
            int foundMines = 0;
            int rows = mines.GetLength(0);
            int cols = mines.GetLength(1);

            if (currentRow - 1 >= 0)
            {
                if (mines[currentRow - 1, currentCol] == '*')
                {
                    foundMines++;
                }
            }

            if (currentRow + 1 < rows)
            {
                if (mines[currentRow + 1, currentCol] == '*')
                {
                    foundMines++;
                }
            }

            if (currentCol - 1 >= 0)
            {
                if (mines[currentRow, currentCol - 1] == '*')
                {
                    foundMines++;
                }
            }

            if (currentCol + 1 < cols)
            {
                if (mines[currentRow, currentCol + 1] == '*')
                {
                    foundMines++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCol - 1 >= 0))
            {
                if (mines[currentRow - 1, currentCol - 1] == '*')
                {
                    foundMines++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCol + 1 < cols))
            {
                if (mines[currentRow - 1, currentCol + 1] == '*')
                {
                    foundMines++;
                }
            }

            if ((currentRow + 1 < rows) && (currentCol - 1 >= 0))
            {
                if (mines[currentRow + 1, currentCol - 1] == '*')
                {
                    foundMines++;
                }
            }

            if ((currentRow + 1 < rows) && (currentCol + 1 < cols))
            {
                if (mines[currentRow + 1, currentCol + 1] == '*')
                {
                    foundMines++;
                }
            }

            return char.Parse(foundMines.ToString());
        }

        // Never used
        private static void CalculateScore(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (board[row, col] != '*')
                    {
                        char minesFound = CountMinesAround(board, row, col);
                        board[row, col] = minesFound;
                    }
                }
            }
        }
    }
}
