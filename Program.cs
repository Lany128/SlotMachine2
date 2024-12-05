using System;

namespace slotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int COLUMNS = 3;

            const int ROWS = 3;

            const int MIN_NUM = 1;

            const int MAX_NUM = 3;

            int betAmount = 0;

            Console.WriteLine("Welcome to the slot Machine Game!");
            Console.WriteLine("Let's start! ");
            int initialBalance;
            //5
            while (true)
            {
                Console.WriteLine("How much would you like to add to your balance?");
                string userInput = Console.ReadLine();

                // check if the indput is a number
                bool isValidNum = int.TryParse(userInput, out initialBalance);

                //check if the balance is too low

                if (isValidNum && initialBalance > 0)
                {
                    break; //if valid input, will excite the loop
                }

                if (!isValidNum)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");

                }

                else
                {
                    Console.WriteLine("Balance too low. Please add more balance or exit the game. ");


                }

            }

            while (initialBalance > 0)
            {
                Console.WriteLine($"Your current balance:${initialBalance}");


                while (true)
                {
                    Console.WriteLine("Enter the amount you want to bet: ");

                    if (int.TryParse(Console.ReadLine(), out betAmount) && betAmount > 0 && betAmount <= initialBalance)
                    {
                        break;
                    }

                    Console.WriteLine("Invalid bet.\nPlease enter a valid indput.");
                }
                string directionChoice = "";

                while (directionChoice != "V" && directionChoice != "H" && directionChoice != "D" && directionChoice != "F")
                {
                    Console.WriteLine("Which direction do you want to try your luck in?");
                    Console.WriteLine("V - vertical\nH - horizotal \nD - diagonal \nF - All direction");



                    if (directionChoice != "V" && directionChoice != "H" && directionChoice != "D" && directionChoice != "F")
                    {
                        Console.WriteLine($"You have chosen {directionChoice}. Are you sure? (press Y or N)");
                        string confirmation = Console.ReadLine().ToUpper();

                        if (confirmation == "Y")
                        {


                        }
                    }


                }

                int[,] slotGrid = new int[COLUMNS, ROWS];
                Random randomNumber = new Random();

                // Fill the array
                for (int i = 0; i < ROWS; i++) // Loop through rows
                {
                    for (int j = 0; j < COLUMNS; j++)// loop through columns
                    {
                        slotGrid[i, j] = randomNumber.Next(MIN_NUM, MAX_NUM);
                    }

                }

                Console.WriteLine("Slot machine result:");

                for (int i = 0; i < ROWS; i++)
                {
                    for (int j = 0; j < COLUMNS; j++)
                    {
                        Console.Write(slotGrid[i, j]); // Print elements in a row
                    }
                    Console.WriteLine();// Move to the next row
                }

                bool checkForWin = false;

                if (directionChoice == "H" || directionChoice == "F")
                {
                    checkForWin = true;
                }
                //****

                if (checkForWin)
                {
                    Console.WriteLine("Jackpot! You've got a winning match");
                    initialBalance += betAmount;

                }
                else
                {
                    Console.WriteLine("No matches found");
                    initialBalance -= betAmount;
                }

                Console.WriteLine($"Your current balance is:${initialBalance}");
            }
        }

        static bool CHECK_HORIZONTAL(int[,] grid, int gridSize)
        {

            for (int ROWS = 0; ROWS < gridSize; ROWS++)
            {
                //check horizontal
                if (grid[ROWS, 0] == grid[ROWS, 1] && grid[ROWS, 1] == grid[ROWS, 2])
                {
                    return true;// if there is any much it will return true
                }
            }
            return false;
        }
        static bool CHECK_VERTICAL(int[,] grid, int gridSize) // will check for the vertical lines
        {
            for (int COLUMNS = 0; COLUMNS < gridSize; COLUMNS++)
            {
                if (grid[0, COLUMNS] == grid[1, COLUMNS] && grid[1, COLUMNS] == grid[0, COLUMNS])
                {
                    return true;
                }

            }
            return false;
        }

        static bool CHECK_DIAGONAL(int[,] grid, int gridSize)// will check for the diagonal lines
        {
            if ((grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2]) ||
                (grid[0, 2] == grid[1, 1] && grid[1, 1] == grid[2, 0]))
            {
                return true;
            }
            return false;

        }


    }

}