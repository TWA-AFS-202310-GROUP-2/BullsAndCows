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
            secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
            int cows = 0;
            int bulls = 0;
            if (guess == null)
            {
                return "4A0B";
            }

            for (int i = 0; i < secret.Length; i++)
            {
                if (guess[i] == secret[i])
                {
                    bulls++;
                }
            }

            for (int i = 0; i < secret.Length; i++)
            {
                if (guess.IndexOf(secret[i]) >= 0 && guess.IndexOf(secret[i]) != i)
                {
                    cows++;
                }
            }

            return $"{bulls}A{cows}B";
        }
    }
}