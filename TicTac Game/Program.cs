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
            Drawboard(board);
            Console.WriteLine();
            
            while (!winner)
            {

                if (One)
                {
                    Console.Write("Player 1: Please choose your field : ");
                    playerOne = PlayerTurn(playerOne);
                    One = !One;
                    board = UpDateOne(playerOne, board);
                    Console.Clear();
                    Drawboard(board);
                    Console.WriteLine();
                    if (WinnerCheck(playerOne))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("PLAYER 1 has won!!!");
                        winner = !winner;
                    }
                }
                else
                {
                    Console.Write("Player 2: Please choose your field : ");
                    playerTwo = PlayerTurn(playerTwo);
                    One = !One;
                    board = UpDateTwo(playerTwo, board);
                    Console.Clear();
                    Drawboard(board);
                    Console.WriteLine();
                    if (WinnerCheck(playerTwo))
                        {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("PLAYER 2 has won!!!");
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
                for (int row = 0; row < 3; row++)
                {
                    Console.WriteLine("       |       |      ");
                    Console.WriteLine("   {0}   |   {1}   |   {2}   ", boardD[row, 0], boardD[row, 1], boardD[row, 2]);
                    if (row == 0 || row == 1)
                    {
                        Console.WriteLine("_______|_______|_______");
                    }
                    else
                    {
                        Console.WriteLine("       |       |");
                    }
                }           
        }

        static int[,] PlayerTurn(int[,] player)
        {
            int box = int.Parse(Console.ReadLine()); // add seciton to check for valid input
            switch (box)
            {
                case 1:
                    player[0, 0] = 1;
                    return player;
                    break;
                case 2:
                    player[0, 1] = 1;
                    return player;
                    break;
                case 3:
                    player[0, 2] = 1;
                    return player;
                    break;
                case 4:
                    player[1, 0] = 1;
                    return player;
                    break;
                case 5:
                    player[1, 1] = 1;
                    return player;
                    break;
                case 6:
                    player[1, 2] = 1;
                    return player;
                    break;
                case 7:
                    player[2, 0] = 1;
                    return player;
                    break;
                case 8:
                    player[2, 1] = 1;
                    return player;
                    break;
                case 9:
                    player[2, 2] = 1;
                    return player;
                    break;
                default:
                    Console.WriteLine("You did not enter a valid square number. Please try again. ");
                    return player;
                    break;
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
