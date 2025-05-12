using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex02.ConsoleUtils;


namespace Ex_02
{
    public class UiManager
    {
        public int NumberOfGuesses { get; set; } // Number of guesses the user wants to have
        private const int LetterCount = 8; // Number of letters in the word (A-H)

        public UiManager() // Constructor
        {
            NumberOfGuesses = GetGuessesNumber();
        }

        public void GameLoop()
        {
            while (true)
            {
                GameEngine gameEngine = new GameEngine();
                string Results = string.Empty;

                PrintResult(Results, string.Empty, 0); // Print the initial empty board

                for (int i = 0; i < NumberOfGuesses; i++)
                {
                    string userInput = Console.ReadLine();

                    if (WordIsQuit(userInput) == true)
                    {
                        Console.WriteLine("Goodbye!");
                        break;
                    }

                    if (IsValidWord(userInput) == true)
                    {
                        Results = gameEngine.CalculateResult(userInput);
                        PrintResult(Results, userInput, i); // Print the current guess and result
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid word.");
                        i--; // Decrement the counter to allow for another guess
                    }

                }

            }
          
        }

        public bool WordIsQuit(string i_WordFromUser)
        {
            bool isQuit = false;
            if (i_WordFromUser.ToUpper() == "Q")
            {
                isQuit = true;
            }
            return isQuit;
        }

        public bool IsValidWord(string i_WordFromUser)
        {
            bool isValid = true;
            int[] countEachAppearance = new int[8];
            string WordFromUserToUpper = i_WordFromUser.ToUpper();

            // Check if the word is exactly 4 characters long and contains only letters A-H
            if (i_WordFromUser.Length != 4)
            {
                isValid = false;
            }
            else
            {
                // Check if the word contains only letters A-H
                foreach (char character in WordFromUserToUpper)
                {
                    countEachAppearance[character - 'A']++; // Increment the count for the corresponding letter

                    if (character < 'A' || character > 'H')
                    {
                        isValid = false;
                        break;
                    }
                }
                // Check if any letter appears more than once 
                for (int i = 0; i < countEachAppearance.Length; i++)
                {
                    if (countEachAppearance[i] > 1)
                    {
                        isValid = false;
                        break;
                    }
                }

            }

            return isValid;
        }

        public int GetGuessesNumber()
        {
            Console.WriteLine("Please enter the number of guesses you want to have (4-10):");

            string input = Console.ReadLine();
            int numberOfGuesses;

            while (!int.TryParse(input, out numberOfGuesses) || numberOfGuesses < 4 || numberOfGuesses > 10)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 10:");
                input = Console.ReadLine();
            }

            return numberOfGuesses;
        }

        public void PrintResult(string i_Result, string i_WordFromUser, int i_NumberOfIteration)
        {
            Ex02.ConsoleUtils.Screen.Clear();

            Console.WriteLine("Current board status:\n");
            Console.WriteLine(" Pins:           Result:");

            for (int i = 0; i < NumberOfGuesses; i++)
            {
                Console.Write("|");

                // Print current guess or empty row
                if (i == i_NumberOfIteration)
                {
                    foreach (char character in i_WordFromUser)
                    {
                        Console.Write($" {character} ");
                    }
                    for (int j = i_WordFromUser.Length; j < 4; j++)
                    {
                        Console.Write("   ");
                    }
                }
                else
                {
                    Console.Write("   ".PadRight(4 * 3));
                }

                Console.Write("|    |");

                // Print result for current guess or empty
                if (i == i_NumberOfIteration)
                {
                    foreach (char character in i_Result)
                    {
                        Console.Write($" {character} ");
                    }
                    for (int j = i_Result.Length; j < 4; j++)
                    {
                        Console.Write("   ");
                    }
                }
                else
                {
                    Console.Write("   ".PadRight(4 * 3));
                }

                Console.WriteLine("|");
                Console.WriteLine("-----------------------------");
            }

            Console.WriteLine("Please type your next guess (A B C D) or 'Q' to quit:");
        }
    }
}
