using System;

namespace TicTac_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] board = new string[,]
            {
                {"1","2","3" },
                {"4","5","6" },
                {"7","8","9" }
            };
            
            int[,] playerOne = new int[,]
            {
                {0,0,0 },
                {0,0,0 },
                {0,0,0 }
            };

            int[,] playerTwo = new int[,]
            {
                {0,0,0 },
                {0,0,0 },
                {0,0,0 }
            };
            bool One = true;
            bool winner = false;
            int endGame = 0;
            Drawboard(board);
            Console.WriteLine();
            
            while (!winner)
            {

                if (One)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Player 1 -");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Please choose your field : ");
                    playerOne = PlayerTurn(playerOne);
                    One = !One;
                    endGame++;
                    board = UpDateOne(playerOne, board);
                    Console.Clear();
                    Drawboard(board);
                    Console.WriteLine();
                    if (WinnerCheck(playerOne))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("PLAYER 1 has won!!!");
                        winner = !winner;
                    }
                    if (endGame == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("Sorry... there is no winner!");
                        winner = !winner;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Player 2 -");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Please choose your field : ");
                    playerTwo = PlayerTurn(playerTwo);
                    One = !One;
                    board = UpDateTwo(playerTwo, board);
                    Console.Clear();
                    Drawboard(board);
                    Console.WriteLine();
                    if (WinnerCheck(playerTwo))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("PLAYER 2 has won!!!");
                        winner = !winner;
                    }
                }
            }
            Console.ReadLine();
        }
        static bool WinnerCheck(int[,] player)
        {
            int sum = 0;
            // check row winner
            for (int i = 0; i < 3; i++)
            {
                sum = player[i, 0] * player[i, 1] * player[i, 2];
                if (sum == 1)
                {
                    return true;
                }
            }
            // check column winner
            for (int i = 0; i < 3; i++)
            {
                sum = player[0, i] * player[1, i] * player[2, i];
                if (sum == 1)
                {
                    return true;
                }
            }
            // check cross-row 1 winner
            if (player[0, 0] * player[1, 1] * player[2,2] == 1)
            {
                return true;
            }
            // check cross-row 2 winner
            if (player[0, 2] * player[1, 1] * player[2, 0] == 1)
            {
                return true;
            }
            return false;
        }

        static void Drawboard(string[,] boardD)
        {               
            Console.WriteLine("       |       |      ");
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    if (boardD[row, column] == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("   {0}   ", boardD[row, column]);
                        Console.ForegroundColor = ConsoleColor.White;
                        if (column == 0 || column == 1)
                        {
                            Console.Write("|");
                        }
                    }
                    else if (boardD[row, column] == "O")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("   {0}   ", boardD[row, column]);
                        Console.ForegroundColor = ConsoleColor.White;
                        if (column == 0 || column == 1)
                        {
                            Console.Write("|");
                        }
                    }
                    else
                    {
                        Console.Write("   {0}   ", boardD[row, column]);
                        if (column == 0 || column == 1)
                        {
                            Console.Write("|");
                        }
                    }
                    if (column == 2)
                    {
                        Console.WriteLine();
                    }
                }
                if (row == 0 || row == 1)
                {
                    Console.WriteLine("_______|_______|_______");
                    Console.WriteLine("       |       |      ");
                }
                else
                {
                        Console.WriteLine("       |       |");
                }
            }           
        }

        static int[,] PlayerTurn(int[,] player)
        {
            bool check = false;
            int box = 10;
            while (!check)
            {
                string selection = Console.ReadLine();
                check = int.TryParse(selection, out box);
                if (!check)
                {
                    Console.WriteLine("You did not enter a valid square number. Please try again. ");
                    Console.WriteLine();
                    Console.Write("Please choose a valid field : ");
                }
            }
            switch (box)
            {
                case 1:
                    player[0, 0] = 1;
                    return player;
                case 2:
                    player[0, 1] = 1;
                    return player;
                case 3:
                    player[0, 2] = 1;
                    return player;
                case 4:
                    player[1, 0] = 1;
                    return player;
                case 5:
                    player[1, 1] = 1;
                    return player;
                case 6:
                    player[1, 2] = 1;
                    return player;
                case 7:
                    player[2, 0] = 1;
                    return player;
                case 8:
                    player[2, 1] = 1;
                    return player;
                case 9:
                    player[2, 2] = 1;
                    return player;
                default:
                    return player;
            }
        }
        
        static string[,] UpDateOne(int[,] newPlayer, string[,] oldBoard)
        {
            for (int i=0; i < 3; i++)
            {
                for (int j=0; j < 3; j++)
                {
                    if (newPlayer[i, j] == 1)
                    {
                        oldBoard[i, j] = "O";
                    }
                }
            }
            return oldBoard;
        }

        static string[,] UpDateTwo(int[,] newPlayer, string[,] oldBoard)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (newPlayer[i, j] == 1)
                    {
                        oldBoard[i, j] = "X";
                    }
                }
            }
            return oldBoard;
        }
    }
}
