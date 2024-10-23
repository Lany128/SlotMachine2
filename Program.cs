using System;
using System.ComponentModel.Design;
using System.Security.Cryptography;

namespace slotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MIN_NUM = 1;
            const int MAX_NUM = 4;
            const int COLUMS = 3;
            const int ROWS = 3;
            const int GRID_SIZE = 3;
            //double inicialAmount = 0;
            // 1)Welcome message
            Console.WriteLine("Welcome to the Slot Machine Game");

            // 2)Player starting balance & amount wishe to play
            Console.WriteLine("Please enter the amount wished to added: ");
            //string userInput = Console.ReadLine();
            int userInicialAmount = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine($"Inicial balance:${userInicialAmount}");

            Console.WriteLine("Amount wished to play: ");

            int userWishedAmoutToPlay =Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Do you wish to bet ${userWishedAmoutToPlay}? Yes/No");
            string amountConfirmation = Console.ReadLine().ToLower();

            if (amountConfirmation == "yes")
            {

                int[,] array2D = new int[COLUMS, ROWS];

                Random randomNumber = new Random();
               

                // Fill the array
                for (int i = 0; i < 3; i++) // Loop through rows
                {
                    for (int j = 0; j < 3; j++)// loop through columns
                    {
                        array2D[i, j] = randomNumber.Next(MIN_NUM, MAX_NUM); // Set each element to 1
                    }

                }

                // 0 1 0 0 0 5/2 ->2.5->2 3/2 -> 1.5 ->1 7/2-> 3.5 ->3
                // 1 1 1 
                // 1 1 0 
                // 1 1 0
                

                //[0,0] -> [1,1] -> [2,2] ....
                //if (array2D[0,0] == array2D[0,j])
                //if (array2D[1,0] == array2D[1,j])

                // Print the 3x3 array
                for (int i = 0; i < GRID_SIZE; i++)
                {
                    for (int j = 0; j < GRID_SIZE; j++)
                    {
                        Console.Write(array2D[i, j]); // Print elements in a row
                    }
                    Console.WriteLine();// Move to the next row
                }

            }
           
            {

            }

            // info if the player has won or lose

            //  update balance

            //ask if the player wishes to play again 

            //Dipouslay info "low balance"

            //End game


           

            



        }
    }

}