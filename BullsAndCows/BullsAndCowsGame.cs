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

        public string Guess(string guess)
        {
            if (this.secret == guess)
            {
                return "4A0B";
            }

            int bulls = 0;
            int cows = 0;
            for (int i = 0; i < secret.Length; i++)
            {
                if (guess.IndexOf(secret[i]) == i)
                {
                    bulls++;
                }
                else if (guess.IndexOf(secret[i]) > 0)
                {
                    cows++;
                }
            }

            return $"{bulls}A{cows}B";
        }
    }
}