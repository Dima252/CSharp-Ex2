using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_02
{
    public class GeneratedGuess
    {
        private static readonly Random rng = new Random();
        public string GeneratedWord { get; set; }

        public GeneratedGuess()
        {
            GeneratedWord = GenerateUniqueFourLetterCode();
        }

        public static string GenerateUniqueFourLetterCode()
        {
            int[] usedLetters = new int[8]; // index 0 = 'A', 1 = 'B', ..., 7 = 'H'
            StringBuilder result = new StringBuilder(4);
            int lettersChosen = 0;

            while (lettersChosen < 4)
            {
                int index = rng.Next(0, 8); // Random number from 0 to 7

                if (usedLetters[index] == 0) // Not yet used
                {
                    char letter = (char)('A' + index);
                    result.Append(letter);
                    usedLetters[index]++;
                    lettersChosen++;
                }
            }

            return result.ToString(); // e.g., "CAGD"
        }

    }
}
