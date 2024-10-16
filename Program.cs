using System;
using System.Security.Cryptography;

namespace slotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MIN_NUM = 1;
            const int MAX_NUM = 4;
            //double inicialAmount = 0;
            // 1)Welcome message
            Console.WriteLine("Welcome to the Slot Machine Game");

            // 2)Player starting balance & amount wishe to play
            Console.WriteLine(" Please enter the amount you wish to add");
            string userInput = Console.ReadLine();
            int userInicialAmount = Convert.ToInt32(userInput);
            
            Console.WriteLine($"Inicial balance:{userInicialAmount}");

                
            // 3) Slot result

            // info if the player has won or lose

            //  update balance

            //ask if the player wishes to play again 

            //Dipouslay info "low balance"

            //End game


            int[,] array2D = new int[3, 3];

            Random randomNumber = new Random();
            /*int slotMachineNum = randomNumber.Next(1,4);*/ //-> 2

            // 1 2 1
            // 1 1 3
            // 3 1 1
            // Fill the array
            for (int i = 0; i < 3; i++) // Loop through rows
            {
                for (int j = 0; j < 3; j++)// loop through columns
                {
                    array2D[i, j] = randomNumber.Next(MIN_NUM, MAX_NUM); // Set each element to 1
                }

            }

            // Print the 3x3 array
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(array2D[i, j]); // Print elements in a row
                }
                Console.WriteLine();// Move to the next row
            }



        }
    }

}