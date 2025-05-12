using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_02
{
    public class GameEngine
    {

        private static readonly Random rng = new Random();
        private string m_GuessedWord;

        public GameEngine()
        {
            m_GuessedWord = GenerateUniqueFourLetterCode();
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

        public string CalculateResult(string i_InputByUser)
        {
            string result = string.Empty;

            int correctLettersInTheRightSpace = 0;
            int existingLetters = 0;

            string guess = i_InputByUser.ToUpper();
            string secret = m_GuessedWord.ToUpper();

            bool[] guessUsed = new bool[4];
            bool[] secretUsed = new bool[4];

            // First pass: correct letters in correct positions
            for (int i = 0; i < 4; i++)
            {
                if (guess[i] == secret[i])
                {
                    correctLettersInTheRightSpace++;
                    guessUsed[i] = true;
                    secretUsed[i] = true;
                }
            }

            // Second pass: correct letters in wrong positions
            for (int i = 0; i < 4; i++)
            {
                if (guessUsed[i]) continue;

                for (int j = 0; j < 4; j++)
                {
                    if (!secretUsed[j] && guess[i] == secret[j])
                    {
                        existingLetters++;
                        secretUsed[j] = true;
                        break;
                    }
                }
            }

            // Build result string
            result = new string('V', correctLettersInTheRightSpace) +
                     new string('X', existingLetters);

            return result;
        }





    }
}
