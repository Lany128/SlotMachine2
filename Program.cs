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
            const string EXIT_GAME = "E";

            int betAmount = 0;

            Console.WriteLine("Welcome to the slot Machine Game!");

            Console.WriteLine("Let's start! ");

            int initialBalance;

            // Loop to get a valid initial balance

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
                    Console.WriteLine("Invalid input. Please enter a positive number.");

                }

                else
                {
                    break;

                }

            }

            while (initialBalance > 0)
            {
                Console.WriteLine($"Your current balance:${initialBalance}");


                while (true)
                {
                    Console.WriteLine("Enter the amount you want to bet: ");

                   

                    if (!int.TryParse(Console.ReadLine(), out betAmount) )
                    {
                        Console.WriteLine("Invalid. Please enter a valid number.");

                    }

                    if ( betAmount <= 0)
                    {
                        Console.WriteLine("Your bet amouot is lower then your balance. Please try again.");
                    }

                    
                    else if (betAmount > initialBalance)
                    {
                        Console.WriteLine("Balance too low.\nInseart a lower bet amount or add more balance");

                        Console.WriteLine("Or if you wish press E to exit the game. ");

                        string existGame = Console.ReadLine().ToUpper();

                        if (existGame == EXIT_GAME)
                        {
                            Console.WriteLine($"You have exit the game.\nYou have finished the game with {initialBalance}");
                            return; //will exit the game when pressed E.
                        }

                        continue;//will continue asking for a valid bet.
                    }

                    break;//will break the loop, and go to the next question of the game.
                }

                string directionChoice = "";  // Initialize a variable to store the direction choice

                while (true)
                {
                    Console.WriteLine("Which direction do you want to try your luck in?");

                    Console.WriteLine("V - vertical\nH - horizotal \nD - diagonal \nF - All direction");

                    directionChoice = Console.ReadLine().ToUpper();

                    if (directionChoice == "V" || directionChoice == "H" || directionChoice == "D" || directionChoice == "F")
                    {
                        Console.WriteLine($"You have chosen {directionChoice}. Is this correct? (press Y or N)");
                        string confirmation = Console.ReadLine().ToUpper();

                        if (confirmation == "Y")
                        {
                            //Breaks the loop when Y is chosen
                            break;

                        }
                        else 
                        {
                            Console.WriteLine("Let's try again");
                        }

                       
                    }

                    else
                    {
                        Console.WriteLine("Invalid direction.");
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
                List<string> winningDirections = new List<string>(); // This is a list to store winning directions and numbers

                bool checkForWin = false;

                int winnings = 0; // Initialize a variable to store the winnings


                if (directionChoice == "H" || directionChoice == "F")// Check if the direction choice is horizontal or all directions
                {

                    for (int i = 0; i < ROWS; i++) // Loop through the rows

                    {

                        if (slotGrid[i, 0] == slotGrid[i, 1] && slotGrid[i, 1] == slotGrid[i, 2]) // Check for a horizontal win

                        {

                            checkForWin = true; // Set checkForWin to true

                            winnings += betAmount; // Earn the bet amount for each winning line
                            winningDirections.Add($" Horizontal (Row{i + 1}: {slotGrid[i, 0]} {slotGrid[i, 1]} {slotGrid[i, 2]})"); // will add the winning row and its numbers.
                        }

                    }

                }
                if (directionChoice == "V" || directionChoice =="F") // check if the directions choise is vertical or all directions

                {
                    for (int j = 0; j <COLUMNS; j++)
                    {
                         
                        if (slotGrid[0,j] == slotGrid[1, j] && slotGrid[1, j] == slotGrid[2,j]) // Check for a vertical win
                        { 
                            checkForWin = true;

                            winnings += betAmount;

                            winningDirections.Add($"Vertical (Column{j + 1}: {slotGrid[0, j]} {slotGrid[1, j]} {slotGrid[2, j]})"); // will add the winnin column and its numbers.
                        }

                    }

                }

                if (directionChoice == "D" ||directionChoice == "F") // check if the directions choise is vertical or all directions

                {
                    for (int j = 0; j < COLUMNS; j++)
                    {

                        if (slotGrid[0, 0] == slotGrid[1, 1] && slotGrid[1, 1] == slotGrid[2, 2]) // Check for a main diagonal win
                           
                        {
                            checkForWin = true;

                            winnings += betAmount;

                            winningDirections.Add($" Main diagonal: {slotGrid[0, 0]} {slotGrid[1, 1]} {slotGrid[2, 2]}");

                        }
                        if (slotGrid[0, 2] == slotGrid[1, 1] && slotGrid[1, 1] == slotGrid[2, 0])// Check for an anti-diagonal win)

                        {
                            checkForWin = true;

                            winnings += betAmount;

                            winningDirections.Add($" Ant-diagonal: {slotGrid[0, 0]} {slotGrid[1, 1]} {slotGrid[2, 2]}");

                        }
                        
                    }

                }

                

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

        // Method to check horizontal winning combinations

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