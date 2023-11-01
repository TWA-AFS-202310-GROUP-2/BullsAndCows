using System;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private string secret;
        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
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