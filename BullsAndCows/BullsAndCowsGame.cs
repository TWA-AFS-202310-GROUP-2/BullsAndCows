using System;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private readonly string secret;
        private int attemps = 0;
        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            this.secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
            if (guess.Length != 4 || !int.TryParse(guess, out _))
            {
                return "Invalid input. Please enter a 4-digit number.";
            }

            attemps++;

            int bulls = 0;
            int cows = 0;
            for (int i = 0; i < secret.Length; i++)
            {
                if (guess.IndexOf(secret[i]) == i)
                {
                    bulls++;
                }
                else if (guess.IndexOf(secret[i]) >= 0)
                {
                    cows++;
                }
            }

            return $"{bulls}A{cows}B";
        }
    }
}