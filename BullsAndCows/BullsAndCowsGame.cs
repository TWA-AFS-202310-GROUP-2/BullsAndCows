using System;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private readonly string secret;
        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            this.secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guess) // input: 4-digit guess and secret, output: guessresult, xAyB
        {
            // cases, secret 1234
            // case 1: all correct case, "1234"-"4A0B"
            // case 2: correct digits, but all wrong locations, "4321"-"0A4B"
            // case 3: some of correct digits with correct locations, "1256"-"2A0B"
            // case 4: some of correct digits with wrong locations, "3456"-"0A2B"
            // case 5: some of correct digits with correct locations, some with wrong loc, "1345"-"1A2B", except for "3A1B"
            // case 6: correct digits, but some are correct loc, some are not, "1432"-"2A2B"
            // case 6: all wrong, "5678"-"0A0B"
            int bulls = 0;
            int cows = 0;
            //if (guess.Equals(secret))
            //{
            //    return "4A0B";
            //}

            for (int i = 0; i < secret.Length; i++)
            {
                if (guess[i] == secret[i]) // same position
                {
                    bulls++;
                }
            }

            for (int i = 0; i < secret.Length; i++)
            {
                if (guess.IndexOf(secret[i]) >= 0 && guess.IndexOf(secret[i]) != i) // correct number, wrong position
                {
                    cows++;
                }
            }

            return $"{bulls}A{cows}B";
        }
    }
}