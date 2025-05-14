using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_02
{
    public class Result
    {
        public string ResultValue { get; set; }
        public Result(Guess i_ValidGuessByUser, GeneratedGuess i_GeneratedGuess)
        {
            ResultValue = GenerateResult(i_ValidGuessByUser, i_GeneratedGuess);
        }

        public string GenerateResult(Guess i_ValidGuessByUser, GeneratedGuess i_GeneratedGuess)
        {
            string result = string.Empty;

            int correctLettersInTheRightSpace = 0;
            int existingLetters = 0;

            string guess = i_ValidGuessByUser.GuessValue.ToUpper();
            string secret = i_GeneratedGuess.GeneratedWord.ToUpper();

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
        public bool GameIsWon()
        {
            if (ResultValue == "VVVV")
            {
                return true;
            }
            return false;
        }

    }
}
